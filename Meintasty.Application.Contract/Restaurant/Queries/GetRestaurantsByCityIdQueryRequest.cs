using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Meintasty.Application.Contract.Restaurant.Queries
{
    [DataContract]
    public class GetRestaurantsByCityIdQueryRequest : IRequest<GeneralResponse<List<GetRestaurantsByCityIdQueryResponse>>>
    {
        [DataMember]
        public int CityCode { get; set; }
        [DataMember]
        public int? CategoryId { get; set; }
        [DataMember]
        public int PageNumber { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [JsonIgnore]
        public bool IsPaging { get; set; }
    }
}
