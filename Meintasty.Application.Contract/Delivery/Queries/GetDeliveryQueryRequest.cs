using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Delivery.Queries
{
    [DataContract]
    public class GetDeliveryQueryRequest : IRequest<GeneralResponse<GetDeliveryQueryResponse>>
    {
    }
}
