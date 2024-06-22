using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.City.Queries
{
    [DataContract]
    public class GetCityQueryRequest : IRequest<GeneralResponse<List<GetCityQueryResponse>>>
    {
    }
}
