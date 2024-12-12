using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;

namespace Meintasty.Data
{
    public class DeliveryRepositoryAsync : MeintastyDbConnection, IDeliveryRepositoryAsync
    {
        public Task<GeneralResponse<Delivery>> AddAsync(Delivery request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Delivery>> DeleteAsync(Delivery request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<Delivery>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Delivery>> GetAsync(Delivery request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Delivery>> UpdateAsync(Delivery request)
        {
            throw new NotImplementedException();
        }
    }
}
