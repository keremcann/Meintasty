using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;

namespace Meintasty.Data
{
    public class CategoryRepositoryAsync : MeintastyDbConnection, ICategoryRepositoryAsync
    {
        public Task<GeneralResponse<Category>> AddAsync(Category request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Category>> DeleteAsync(Category request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<Category>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Category>> GetAsync(Category request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Category>> UpdateAsync(Category request)
        {
            throw new NotImplementedException();
        }
    }
}
