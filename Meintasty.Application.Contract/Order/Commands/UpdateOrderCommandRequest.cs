using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Order.Commands
{
    [DataContract]
    public class UpdateOrderCommandRequest : IRequest<GeneralResponse<UpdateOrderCommandResponse>>
    {
    }
}
