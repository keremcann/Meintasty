using Meintasty.Core.Common;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;

namespace Meintasty.Domain.Repository
{
    public interface ICategoryRepositoryAsync : IRepositoryAsync<Category>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<Category>>> GetAllByInfoAsync(Category request);
    }
}
