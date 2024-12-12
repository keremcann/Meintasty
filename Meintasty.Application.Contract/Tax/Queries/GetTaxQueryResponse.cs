using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Tax.Queries
{
    [DataContract]
    public class GetTaxQueryResponse
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
