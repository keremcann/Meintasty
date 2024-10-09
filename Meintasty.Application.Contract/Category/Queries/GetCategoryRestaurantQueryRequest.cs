using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Category.Queries
{
    [DataContract]
    public class GetCategoryRestaurantQueryRequest : IRequest<GeneralResponse<List<GetCategoryRestaurantQueryResponse>>>
    {
        [DataMember]
        public int CategoryId { get; set; }
    }
}
