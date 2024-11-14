using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Basket.Commands
{
    [DataContract]
    public class CreateBasketCommandRequest : IRequest<GeneralResponse<CreateBasketCommandResponse>>
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int RestaurantId { get; set; }
        [DataMember]
        public int MenuId { get; set; }
        [DataMember]
        public string? BasketDate { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public string? CurrencyCode { get; set; }
    }
}
