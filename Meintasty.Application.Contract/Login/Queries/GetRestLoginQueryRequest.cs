using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Meintasty.Application.Contract.Login.Queries
{
    [DataContract]
    public class GetRestLoginQueryRequest : IRequest<GeneralResponse<GetRestLoginQueryResponse>>
    {
        [JsonIgnore]
        public int RestaurantId { get; set; }
        [JsonIgnore]
        public string? FullName { get; set; }
        [DataMember]
        public string? Email { get; set; }
        [DataMember]
        public string? Password { get; set; }
        [JsonIgnore]
        public string? Url { get; set; }
        [JsonIgnore]
        public string? PhoneNumber { get; set; }
    }
}
