using Meintasty.Core.Common;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;

namespace Meintasty.Domain.Repository
{
    public interface IRestaurantMenuRepositoryAsync : IRepositoryAsync<RestaurantMenu>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<RestaurantMenu>>> GetAllByIdAsync(int id);
    }
}
