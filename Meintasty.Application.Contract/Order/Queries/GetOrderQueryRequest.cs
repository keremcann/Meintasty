using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Order.Queries
{
    [DataContract]
    public class GetOrderQueryRequest : IRequest<GeneralResponse<GetOrderQueryResponse>>
    {
        //[DataMember]
        //public int? UserId { get; set; }
        [DataMember]
        public int? RestaurantId { get; set; }
        [DataMember]
        public int PageNumber { get; set; }
    }
}
