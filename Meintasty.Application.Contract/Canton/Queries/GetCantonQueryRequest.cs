using MediatR;
using Meintasty.Core.Common;

namespace Meintasty.Application.Contract.Canton.Queries
{
    [Serializable]
    public class GetCantonQueryRequest : IRequest<GeneralResponse<List<GetCantonQueryResponse>>>
    {
    }
}
