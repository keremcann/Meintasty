using Meintasty.Core.Common;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;

namespace Meintasty.Domain.Repository
{
    public interface IOrderRepositoryAsync : IRepositoryAsync<Order>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pagesize"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<Order>>> GetAllByInfoAsync(Order request, int pagesize, int offset);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="resId"></param>
        /// <returns></returns>
        Task<GeneralResponse<Int32>> GetTotalCountAsync(int userId, int resId);
    }
}
