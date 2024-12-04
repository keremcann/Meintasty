using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Restaurant
{
    [DataContract]
    public class RestaurantOrderContract
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public DateTime? OrderDate { get; set; }
        [DataMember]
        public string? OrderPrice { get; set; }
        [DataMember]
        public string? Currency { get; set; }
        [DataMember]
        public string? PaymentType { get; set; }
        [DataMember]
        public string? OrderTip { get; set; }
        [DataMember]
        public bool? IsPaid { get; set; }
    }
}
