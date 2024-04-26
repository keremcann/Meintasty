using Meintasty.Core.Common;

namespace Meintasty.Application.Contract.Login.Queries
{
    [Serializable]
    public class GetLoginQueryResponse
    {
        public string? Token { get; set; }
        public string? FullName { get; set; }
    }
}
