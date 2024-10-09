using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Register.Commands
{
    [DataContract]
    public class CreateUserCommandRequest : IRequest<GeneralResponse<CreateUserCommandResponse>>
    {
        [DataMember]
        public string? FullName { get; set; }
        [DataMember]
        public string? Email { get; set; }
        [DataMember]
        public string? PhoneNumber { get; set; }
        [DataMember]
        public string? Password { get; set; }
        [DataMember]
        public string? RePassword { get; set; }
    }
}
