using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.User.Commands
{
    [DataContract]
    public class UpdateUserCommandRequest : IRequest<GeneralResponse<UpdateUserCommandResponse>>
    {
    }
}
