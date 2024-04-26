using MediatR;

namespace Meintasty.Application.Contract.Login.Queries
{
    [Serializable]
    public class GetLoginQueryRequest : IRequest<GetLoginQueryResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
