using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Category.Queries
{
    [DataContract]
    public class GetCategoryQueryRequest : IRequest<GeneralResponse<List<GetCategoryQueryResponse>>>
    {
    }
}
