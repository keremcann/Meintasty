
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Register.Commands
{
    [DataContract]
    public class CreateUserCommandResponse
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string? FullName { get; set; }
        [DataMember]
        public string? Token { get; set; }
        [DataMember]
        public List<string>? RoleList { get; set; }
    }
}
