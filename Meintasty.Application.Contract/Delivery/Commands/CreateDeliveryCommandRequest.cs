using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Delivery.Commands
{
    [DataContract]
    public class CreateDeliveryCommandRequest : IRequest<GeneralResponse<CreateDeliveryCommandResponse>>
    {
    }
}
