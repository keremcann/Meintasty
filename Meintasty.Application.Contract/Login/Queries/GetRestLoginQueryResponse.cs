using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Meintasty.Application.Contract.Login.Queries
{
    [DataContract]
    public class GetRestLoginQueryResponse
    {
        [DataMember]
        public int RestaurantId { get; set; }
        [DataMember]
        public string? Token { get; set; }
        [DataMember]
        public string? FullName { get; set; }
        [JsonIgnore]
        public string? Url { get; set; }
        [JsonIgnore]
        public string? PhoneNumber { get; set; }
        [DataMember]
        public List<string>? RoleList { get; set; }
    }
}
