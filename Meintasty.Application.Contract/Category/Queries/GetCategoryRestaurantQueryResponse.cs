using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Category.Queries
{
    [DataContract]
    public class GetCategoryRestaurantQueryResponse
    {
        public GetCategoryRestaurantQueryResponse()
        {
            Categories = new List<GetCategoryQueryResponse>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string? RestaurantName { get; set; }
        [DataMember]
        public int StarCount { get; set; }
        [DataMember]
        public int MinTime { get; set; }
        [DataMember]
        public string? MinBudget { get; set; }
        [DataMember]
        public string? CurrencyCode { get; set; }
        [DataMember]
        public string? Delivery { get; set; }
        [DataMember]
        public List<GetCategoryQueryResponse>? Categories { get; set; }
    }
}
