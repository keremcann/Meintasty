using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class RestaurantAddressRepositoryAsync : MeintastyDbConnection, IRestaurantAddressRepositoryAsync
    {
        public Task<GeneralResponse<RestaurantAddress>> AddAsync(RestaurantAddress request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<RestaurantAddress>> DeleteAsync(RestaurantAddress request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<RestaurantAddress>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<RestaurantAddress>>> GetAllByIdAsync(int id)
        {
            var data = new GeneralResponse<List<RestaurantAddress>>();
            data.Value = new List<RestaurantAddress>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@RestaurantId", id);

            try
            {
                data.Value = connection?.db?.QueryAsync<RestaurantAddress>("sel_AllAddressByRestaurantId", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
                data.Success = true;
                connection?.db?.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection?.db?.Close();
                return await Task.FromResult(data);
            }
        }

        public Task<GeneralResponse<RestaurantAddress>> GetAsync(RestaurantAddress request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<RestaurantAddress>> UpdateAsync(RestaurantAddress request)
        {
            throw new NotImplementedException();
        }
    }
}
