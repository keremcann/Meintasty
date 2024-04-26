using MediatR;

namespace Meintasty.Application.Contract.Register.Commands
{
    [Serializable]
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
    }
}
