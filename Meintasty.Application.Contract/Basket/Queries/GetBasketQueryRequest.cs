using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Basket.Queries
{
    [DataContract]
    public class GetBasketQueryRequest : IRequest<GeneralResponse<List<GetBasketQueryResponse>>>
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int RestaurantId { get; set; }
    }
}
