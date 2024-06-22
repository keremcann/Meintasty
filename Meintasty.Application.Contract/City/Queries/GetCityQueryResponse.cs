using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.City.Queries
{
    [DataContract]
    public class GetCityQueryResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string? CityName { get; set; }
        [DataMember]
        public int CityCode { get; set; }
    }
}
