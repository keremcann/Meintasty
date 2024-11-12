using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Order.Queries
{
    [DataContract]
    public class GetOrderQueryResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int RestaurantId { get; set; }
        [DataMember]
        public string? Name { get; set; }
        [DataMember]
        public string? OrderDate { get; set; }
        [DataMember]
        public string? Price { get; set; }
        [DataMember]
        public string? CurrencyCode { get; set; }
        [DataMember]
        public string? PaymentType { get; set; }
        [DataMember]
        public string? OrderTip { get; set; }
    }
}
