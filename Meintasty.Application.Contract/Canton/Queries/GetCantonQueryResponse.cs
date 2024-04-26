using Meintasty.Application.Contract.City.Queries;
using Meintasty.Core.Common;

namespace Meintasty.Application.Contract.Canton.Queries
{
    [Serializable]
    public class GetCantonQueryResponse
    {
        public int Id { get; set; }
        public string? CantonName { get; set; }
        public List<GetCityQueryResponse>? Cities { get; set; }
    }
}
