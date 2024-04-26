using MediatR;
using Meintasty.Core.Common;

namespace Meintasty.Application.Contract.Login.Queries
{
    [Serializable]
    public class GetLoginQueryRequest : IRequest<GeneralResponse<GetLoginQueryResponse>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
