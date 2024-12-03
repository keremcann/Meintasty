using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Category.Queries
{
    [DataContract]
    public class GetCategoryQueryResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember] 
        public string? CategoryName { get; set; }
        [DataMember]
        public int? RestaurantCount { get; set;}
    }
}
