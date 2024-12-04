using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Restaurant
{
    [DataContract]
    public class RestaurantMenuContract
    {
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public int MenuId { get; set; }
        [DataMember]
        public string? CategoryName { get; set; }
        [DataMember]
        public string? MenuName { get; set; }
        [DataMember]
        public string? MenuContent { get; set; }
        [DataMember]
        public string? MenuPrice { get; set; }
        [DataMember]
        public string? Currency { get; set; }
        [DataMember]
        public byte[]? MenuPic { get; set;}
    }
}
