using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.User.Commands
{
    [DataContract]
    public class UpdateUserEmailCommandRequest : IRequest<GeneralResponse<UpdateUserEmailCommandResponse>>
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string? Email { get; set; }
    }
}
