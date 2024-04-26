using Meintasty.Core.Common;
using System.Data;

namespace Meintasty.Core.Connection
{
    public class DbConnectionResult : BaseResponse
    {
        public IDbConnection? db { get; set; }
    }
}
