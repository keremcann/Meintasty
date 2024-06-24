using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Restaurant.Queries
{
    [DataContract]
    public class GetRestaurantDetailByIdQueryResponse
    {
        [DataMember]
        public string? RestaurantName { get; set; }
        [DataMember]
        public string? Email { get; set; }
        [DataMember]
        public string? PhoneNumber { get; set; }
        [DataMember]
        public string? TaxNumber { get; set; }
        [DataMember]
        public string? WorkDayFrom { get; set; }
        [DataMember]
        public string? WorkDayTo { get; set; }
        [DataMember]
        public string? WorkHourFrom { get; set; }
        [DataMember]
        public string? WorkHourTo { get; set; }
        [DataMember]
        public List<RestaurantAddressContract>? AddressList { get; set; }
        [DataMember]
        public List<RestaurantMenuContract>? MenuList { get; set;}
        [DataMember]
        public List<RestaurantOrderContract>? OrderList { get; set; }
    }
}
