using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.User.Commands
{
    [DataContract]
    public class UpdateUserCommandRequest : IRequest<GeneralResponse<UpdateUserCommandResponse>>
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string? FullName { get; set; }
        [DataMember]
        public string? Email { get; set; }
        [DataMember]
        public string? PhoneNumber { get; set; }
        [DataMember]
        public string? Gender { get; set; }
        [DataMember]
        public string? BirthDate { get; set; }
        [DataMember]
        public bool? IsEmailVerified { get; set; }
        [DataMember]
        public bool? IsPhoneVerified { get; set; }
        [DataMember]
        public byte[]? ProfilePicture { get; set; }
        [DataMember]
        public string? Password { get; set; }
    }
}
