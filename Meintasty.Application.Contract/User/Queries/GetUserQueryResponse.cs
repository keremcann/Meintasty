using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.User.Queries
{
    [DataContract]
    public class GetUserQueryResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string? FullName { get; set; }
        [DataMember]
        public string? Email { get; set; }
        [DataMember]
        public string? PhoneNumber { get; set; }
        [DataMember]
        public byte[]? ProfilePicture { get; set; }
    }
}
