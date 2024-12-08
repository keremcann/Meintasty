using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Restaurant.Queries
{
    [DataContract]
    public class GetRestaurantDetailByInfoQueryRequest : IRequest<GeneralResponse<GetRestaurantDetailByInfoQueryResponse>>
    {
        [DataMember]
        public string? Url { get; set; }
    }
}
