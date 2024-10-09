using MediatR;
using Meintasty.Application.Contract.User.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.User
{
    public class UpdateUserPhoneCommandHandler : IRequestHandler<UpdateUserPhoneCommandRequest, GeneralResponse<UpdateUserPhoneCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepositoryAsync _userRepository;

        public UpdateUserPhoneCommandHandler(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<UpdateUserPhoneCommandResponse>> Handle(UpdateUserPhoneCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<UpdateUserPhoneCommandResponse>();
            response.Value = new UpdateUserPhoneCommandResponse();

            var result = await _userRepository.UpdateUserPhoneAsync(new Domain.Entity.User
            {
                Id = request.UserId,
                PhoneNumber = request.PhoneNumber,
                UpdateUser = 1,
                UpdateDate = DateTime.UtcNow
            });

            if (!result.Success)
            {
                response.Success = result.Success;
                response.ErrorMessage = result.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Process finised successfully!";

            return await Task.FromResult(response);
        }
    }
}
