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
        /// <param name="item"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<Order>>> GetAllByInfoAsync(Order request);
    }
}
