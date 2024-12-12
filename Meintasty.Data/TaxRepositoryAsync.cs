using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;

namespace Meintasty.Data
{
    public class TaxRepositoryAsync : MeintastyDbConnection, ITaxRepositoryAsync
    {
        public Task<GeneralResponse<Tax>> AddAsync(Tax request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Tax>> DeleteAsync(Tax request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<Tax>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Tax>> GetAsync(Tax request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Tax>> UpdateAsync(Tax request)
        {
            throw new NotImplementedException();
        }
    }
}
