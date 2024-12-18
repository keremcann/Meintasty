using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Delivery.Queries
{
    [DataContract]
    public class GetDeliveryQueryResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string? MinAmount { get; set; }
        [DataMember]
        public string? MaxAmount { get; set; }
        [DataMember]
        public string? MinDistance { get; set; }
        [DataMember]
        public string? MaxDistance { get; set; }
        [DataMember]
        public string? Currency { get; set; }
        [DataMember]
        public string? Description { get; set; }
        [DataMember]
        public bool IsFree { get; set; }
    }
}
