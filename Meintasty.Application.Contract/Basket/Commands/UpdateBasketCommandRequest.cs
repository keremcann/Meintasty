using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Basket.Commands
{
    [DataContract]
    public class UpdateBasketCommandRequest : IRequest<GeneralResponse<UpdateBasketCommandResponse>>
    {
    }
}
