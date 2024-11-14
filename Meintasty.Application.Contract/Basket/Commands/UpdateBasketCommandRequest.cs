using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Basket.Commands
{
    [DataContract]
    public class UpdateBasketCommandRequest : IRequest<GeneralResponse<UpdateBasketCommandResponse>>
    {
        [DataMember]
        public int BasketId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
