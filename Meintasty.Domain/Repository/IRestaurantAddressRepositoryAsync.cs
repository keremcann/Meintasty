using Meintasty.Core.Common;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;

namespace Meintasty.Domain.Repository
{
    public interface IRestaurantAddressRepositoryAsync : IRepositoryAsync<RestaurantAddress>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<RestaurantAddress>>> GetAllByIdAsync(int id);
    }
}
