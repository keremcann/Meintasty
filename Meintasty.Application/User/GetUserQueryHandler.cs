using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Canton.Queries;
using Meintasty.Application.Contract.User.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GeneralResponse<GetUserQueryResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IUserRepositoryAsync _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public GetUserQueryHandler(IMapper mapper,IUserRepositoryAsync userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
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

            var user = _userRepository.GetByIdAsync(request.UserId);

            if (!user.Result.Success)
            {
                response.Success = user.Result.Success;
                response.ErrorMessage = user.Result.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (user.Result.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found any User!";
                return await Task.FromResult(response);
            }
            response.Value = _mapper.Map<GetUserQueryResponse>(user.Result.Value);
            response.Success = true;
            response.ErrorMessage = "Successfull!";
            return await Task.FromResult(response);
        }
    }
}
