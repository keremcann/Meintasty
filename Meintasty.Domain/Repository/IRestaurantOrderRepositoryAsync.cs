using Meintasty.Core.Common;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;

namespace Meintasty.Domain.Repository
{
    public interface IRestaurantOrderRepositoryAsync : IRepositoryAsync<RestaurantOrder>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<RestaurantOrder>>> GetAllByIdAsync(int id);
    }
}
