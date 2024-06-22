
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Register.Commands
{
    [DataContract]
    public class CreateUserCommandResponse
    {
        [DataMember]
        public string FullName { get; set; }
    }
}
