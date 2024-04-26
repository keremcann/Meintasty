using MediatR;
using Meintasty.Application.Contract.Register.Commands;
using Meintasty.Core.Common;

namespace Meintasty.Application.Register
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, GeneralResponse<CreateUserCommandResponse>>
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
        public async Task<GeneralResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateUserCommandResponse>();

            return await Task.FromResult(response);
        }
    }
}
