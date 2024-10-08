using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Basket.Queries
{
    [DataContract]
    public class GetBasketQueryResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int RestaurantId { get; set; }
        [DataMember]
        public int MenuId { get; set; }
        [DataMember]
        public string? RestaurantName { get; set; }
        [DataMember]
        public string? MenuName { get; set; }
        [DataMember]
        public DateTime BasketDate { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string? Price { get; set; }
        [DataMember]
        public string? CurrencyCode { get; set; }
    }
}
