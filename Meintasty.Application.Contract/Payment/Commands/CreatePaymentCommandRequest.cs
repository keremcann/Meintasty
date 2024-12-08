using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Payment.Commands
{
    [DataContract]
    public class CreatePaymentCommandRequest : IRequest<GeneralResponse<CreatePaymentCommandResponse>>
    {
    }
}
