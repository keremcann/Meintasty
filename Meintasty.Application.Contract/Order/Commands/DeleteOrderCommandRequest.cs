using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Order.Commands
{
    [DataContract]
    public class DeleteOrderCommandRequest : IRequest<GeneralResponse<DeleteOrderCommandResponse>>
    {
    }
}
