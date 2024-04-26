namespace Meintasty.Application.Contract.City.Queries
{
    [Serializable]
    public class GetCityQueryResponse
    {
        public int Id { get; set; }
        public string? CityName { get; set; }
        public int CityCode { get; set; }
    }
}
