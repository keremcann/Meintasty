using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.User.Commands
{
    [DataContract]
    public class DeleteUserCommandRequest : IRequest<GeneralResponse<DeleteUserCommandResponse>>
    {
        [DataMember]
        public int UserId { get; set; }
    }
}
