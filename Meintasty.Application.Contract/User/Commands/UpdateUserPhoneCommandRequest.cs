using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.User.Commands
{
    [DataContract]
    public class UpdateUserPhoneCommandRequest : IRequest<GeneralResponse<UpdateUserPhoneCommandResponse>>
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string? PhoneNumber { get; set; }
    }
}
