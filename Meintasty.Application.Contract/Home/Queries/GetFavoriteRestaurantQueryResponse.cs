using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Home.Queries
{
    [DataContract]
    public class GetFavoriteRestaurantQueryResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string? RestaurantName { get; set; }
        [DataMember]
        public byte[]? RestaurantImage { get; set; }
        [DataMember]
        public string? Description { get; set; }
    }
}
