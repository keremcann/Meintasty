using MediatR;
using Meintasty.Core.Common;

namespace Meintasty.Application.Contract.City.Queries
{
    [Serializable]
    public class GetCityQueryRequest : IRequest<GeneralResponse<List<GetCityQueryResponse>>>
    {
    }
}
