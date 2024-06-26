using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.User.Queries
{
    [DataContract]
    public class GetUserQueryRequest : IRequest<GeneralResponse<GetUserQueryResponse>>
    {
        [DataMember]
        public int UserId { get; set; }
    }
}
