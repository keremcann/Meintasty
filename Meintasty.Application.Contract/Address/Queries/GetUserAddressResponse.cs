using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Address.Queries
{
    [DataContract]
    public class GetUserAddressResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string? AddressName { get; set; }
        [DataMember]
        public string? AddressText { get; set; }
        [DataMember]
        public string? Street { get; set; }
        [DataMember]
        public int CityCode { get; set; }
        [DataMember]
        public string? CityName { get; set; }
        [DataMember]
        public string? CantonName { get; set; }
        [DataMember]
        public string? ZipCode { get; set; }
        [DataMember]
        public bool IsDefault { get; set; }
    }
}
