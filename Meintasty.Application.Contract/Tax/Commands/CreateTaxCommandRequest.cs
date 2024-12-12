using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Tax.Commands
{
    [DataContract]
    public class CreateTaxCommandRequest : IRequest<GeneralResponse<CreateTaxCommandResponse>>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string? Name { get; set; }
        [DataMember]
        public string? Amount { get; set; }
        [DataMember]
        public string? Currency { get; set; }
        [DataMember]
        public string? Description { get; set; }
    }
}
