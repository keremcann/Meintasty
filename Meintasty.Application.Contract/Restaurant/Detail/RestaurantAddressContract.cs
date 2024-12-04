using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Restaurant
{
    [DataContract]
    public class RestaurantAddressContract
    {
        [DataMember]
        public int AddressId { get; set; }
        [DataMember]
        public string? AddressName { get; set; }
        [DataMember]
        public string? AddressText { get; set; }
        [DataMember]
        public string? Street { get; set; }
        [DataMember]
        public int CityCode { get; set; }
    }
}
