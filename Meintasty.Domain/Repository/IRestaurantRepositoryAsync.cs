using Meintasty.Core.Common;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;

namespace Meintasty.Domain.Repository
{
    public interface IRestaurantRepositoryAsync : IRepositoryAsync<Restaurant>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<Restaurant>>> GetAllByCityIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="pageSize"></param>
        /// <param name="offset"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<Restaurant>>> GetAllByCityIdWithPagingAsync(int cityId, int pageSize, int offset, List<int>? categoryIdList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<Restaurant>>> GetAllByCategoryIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<GeneralResponse<List<Restaurant>>> GetFavoritesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="categoryIdList"></param>
        /// <returns></returns>
        Task<GeneralResponse<Int32>> GetTotalCountAsync(int cityId, List<int>? categoryIdList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<GeneralResponse<Restaurant>> GetRestaurantByInfoAsync(string email, string password);
    }
}
