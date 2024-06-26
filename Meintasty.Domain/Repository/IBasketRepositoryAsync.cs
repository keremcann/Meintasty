using Meintasty.Core.Common;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;

namespace Meintasty.Domain.Repository
{
    public interface IBasketRepositoryAsync : IRepositoryAsync<Basket>
    {
        Task<GeneralResponse<List<Basket>>> GetAllByInfoAsync(Basket request);
    }
}
