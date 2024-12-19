using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Tax.Queries
{
    [DataContract]
    public class GetTaxQueryRequest : IRequest<GeneralResponse<List<GetTaxQueryResponse>>>
    {
        [DataMember]
        public int? TaxId { get; set;}
    }
}
