using MediatR;
using Meintasty.Application.Contract.User.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.User
{
    public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommandRequest, GeneralResponse<UpdateUserPasswordCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepositoryAsync _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public UpdateUserPasswordCommandHandler(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<UpdateUserPasswordCommandResponse>> Handle(UpdateUserPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<UpdateUserPasswordCommandResponse>();
            response.Value = new UpdateUserPasswordCommandResponse();

            var result = await _userRepository.UpdateUserPasswordAsync(new Domain.Entity.User
            {
                Id = request.UserId,
                Password = request.Password,
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
