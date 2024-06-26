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

            return await Task.FromResult(response);
        }
    }
}
