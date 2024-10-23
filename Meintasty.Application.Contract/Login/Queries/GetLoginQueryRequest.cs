using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Meintasty.Application.Contract.Login.Queries
{
    [DataContract]
    public class GetLoginQueryRequest : IRequest<GeneralResponse<GetLoginQueryResponse>>
    {
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public string? FullName { get; set; }
        [DataMember]
        public string? Email { get; set; }
        [DataMember]
        public string? Password { get; set; }
    }
}
