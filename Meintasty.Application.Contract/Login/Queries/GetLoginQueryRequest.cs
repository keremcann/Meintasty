using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Login.Queries
{
    [DataContract]
    public class GetLoginQueryRequest : IRequest<GeneralResponse<GetLoginQueryResponse>>
    {
        [DataMember]
        public string? Email { get; set; }
        [DataMember]
        public string? Password { get; set; }
    }
}
