using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Order.Commands
{
    [DataContract]
    public class CreateOrderCommandRequest : IRequest<GeneralResponse<CreateOrderCommandResponse>>
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int RestaurantId { get; set; }
        [DataMember]
        public string? OrderDate { get; set; }
        [DataMember]
        public string? PaymentType { get; set; }
        [DataMember]
        public string? Price { get; set; }
        [DataMember]
        public string? CurrencyCode { get; set; }
        [DataMember]
        public string? OrderTip { get; set;}
    }
}
