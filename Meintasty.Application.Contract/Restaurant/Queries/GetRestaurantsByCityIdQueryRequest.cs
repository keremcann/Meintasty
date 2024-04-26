using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Restaurant.Queries
{
    [DataContract]
    public class GetRestaurantsByCityIdQueryRequest : IRequest<GeneralResponse<List<GetRestaurantsByCityIdQueryResponse>>>
    {
        [DataMember]
        public int CityCode { get; set; }
    }
}
