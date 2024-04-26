using Meintasty.Core.Common;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;

namespace Meintasty.Domain.Repository
{
    public interface IRestaurantRepositoryAsync : IRepositoryAsync<Restaurant>
    {
        Task<GeneralResponse<List<Restaurant>>> GetAllByCityIdAsync(int id);
    }
}
