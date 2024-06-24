using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Restaurant.Queries
{
    [DataContract]
    public class GetRestaurantDetailByIdQueryRequest : IRequest<GeneralResponse<GetRestaurantDetailByIdQueryResponse>>
    {
        [DataMember]
        public int RestaurantId { get; set; }
    }
}
