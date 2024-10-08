using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Home.Queries
{
    [DataContract]
    public class GetFavoriteMenuQueryRequest : IRequest<GeneralResponse<List<GetFavoriteMenuQueryResponse>>>
    {
    }
}
