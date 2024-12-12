using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Address.Queries;
using Meintasty.Application.Contract.User.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using Meintasty.Domain.Shared.Globals;

namespace Meintasty.Application.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GeneralResponse<GetUserQueryResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IUserAddressRepositoryAsync _userAddressRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public GetUserQueryHandler(IMapper mapper,IUserRepositoryAsync userRepository, IUserAddressRepositoryAsync userAddressRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userAddressRepository = userAddressRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<GetUserQueryResponse>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetUserQueryResponse>();
            response.Value = new GetUserQueryResponse();

            var user = await _userRepository.GetByIdAsync(UserSettings.UserId);

            if (!user.Success)
            {
                response.Success = user.Success;
                response.ErrorMessage = user.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (user.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found any User!";
                return await Task.FromResult(response);
            }

            var address = await _userAddressRepository.GetAsync(new UserAddress { UserId = UserSettings.UserId });
            if (!address.Success)
            {
                response.Success = address.Success;
                response.ErrorMessage = address.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Value = _mapper.Map<GetUserQueryResponse>(user.Value);
            response.Value.UserAdddress = _mapper.Map<GetUserAddressResponse>(address.Value);
            response.Success = true;
            response.InfoMessage = "Process finised successfully!";
            return await Task.FromResult(response);
        }
    }
}
