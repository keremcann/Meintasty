using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Basket.Commands
{
    [DataContract]
    public class DeleteBasketCommandRequest : IRequest<GeneralResponse<DeleteBasketCommandResponse>>
    {
        [DataMember]
        public int BasketId { get; set; }
    }
}
