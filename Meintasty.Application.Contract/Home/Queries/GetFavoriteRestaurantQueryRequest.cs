using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Home.Queries
{
    [DataContract]
    public class GetFavoriteRestaurantQueryRequest : IRequest<GeneralResponse<List<GetFavoriteRestaurantQueryResponse>>>
    {
    }
}
