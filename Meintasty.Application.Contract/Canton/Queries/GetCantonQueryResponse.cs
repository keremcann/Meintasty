using Meintasty.Application.Contract.City.Queries;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Canton.Queries
{
    [DataContract]
    public class GetCantonQueryResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string? CantonName { get; set; }
        [DataMember]
        public List<GetCityQueryResponse>? Cities { get; set; }
    }
}
