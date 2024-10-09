using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Login.Queries
{
    [DataContract]
    public class GetLoginQueryResponse
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string? Token { get; set; }
        [DataMember]
        public string? FullName { get; set; }
        [DataMember]
        public List<string>? RoleList { get; set; }
    }
}
