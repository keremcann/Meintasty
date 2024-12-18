using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Delivery.Commands
{
    [DataContract]
    public class CreateOrderDeliveryCommandRequest : IRequest<GeneralResponse<CreateOrderDeliveryCommandResponse>>
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public string? Status { get; set; }
        [DataMember]
        public string? Description { get; set; }
    }
}
