using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Home.Queries
{
    [DataContract]
    public class GetFavoriteMenuQueryResponse
    {
        [DataMember]
        public int RestaurantId { get; set; }
        [DataMember]
        public int MenuId { get; set; }
        [DataMember]
        public string? MenuName { get; set; }
        [DataMember]
        public string? Price { get; set; }
        [DataMember]
        public string? Currency { get; set; }
        [DataMember]
        public byte[]? MenuPic { get; set; }
    }
}
