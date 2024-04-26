using MediatR;
using Meintasty.Application.Contract.Register.Commands;

namespace Meintasty.Application.Register
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserCommandHandler()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateUserCommandResponse();

            return await Task.FromResult(response);
        }
    }
}
