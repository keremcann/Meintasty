using Meintasty.Application.Contract.Address;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.User.Queries
{
    [DataContract]
    public class GetUserQueryResponse
    {
        public GetUserAddressResponse UserAdddress { get; set; }
        public GetUserQueryResponse()
        {
            UserAdddress = new GetUserAddressResponse();
        }
        [DataMember]
        public int Id { get; set; }
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
        public byte[]? ProfilePicture { get; set; }
        [DataMember]
        public bool? IsEmailVerified { get; set; }
        [DataMember]
        public bool? IsPhoneVerified { get; set; }
    }
}
