using MediatR;
using Meintasty.Core.Common;

namespace Meintasty.Application.Contract.Register.Commands
{
    [Serializable]
    public class CreateUserCommandRequest : IRequest<GeneralResponse<CreateUserCommandResponse>>
    {
    }
}
