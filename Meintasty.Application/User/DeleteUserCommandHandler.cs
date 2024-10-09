using MediatR;
using Meintasty.Application.Contract.User.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, GeneralResponse<DeleteUserCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepositoryAsync _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public DeleteUserCommandHandler(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<DeleteUserCommandResponse>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<DeleteUserCommandResponse>();
            response.Value = new DeleteUserCommandResponse();

            var result = await _userRepository.DeleteAsync(new Domain.Entity.User
            {
                Id = request.UserId
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
