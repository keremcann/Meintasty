using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.User.Commands
{
    [DataContract]
    public class UpdateUserPasswordCommandRequest : IRequest<GeneralResponse<UpdateUserPasswordCommandResponse>>
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string? Password { get; set; }
    }
}
