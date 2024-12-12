using Meintasty.Core.Common;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;

namespace Meintasty.Domain.Repository
{
    public interface IBasketRepositoryAsync : IRepositoryAsync<Basket>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<Basket>>> GetAllByInfoAsync(Basket request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<GeneralResponse<Basket>> DeleteAllByUserIdAsync(int userId);
    }
}
