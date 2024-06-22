using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Canton.Queries
{
    [DataContract]
    public class GetCantonQueryRequest : IRequest<GeneralResponse<List<GetCantonQueryResponse>>>
    {
    }
}
