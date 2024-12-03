using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class RestaurantOrderRepositoryAsync : MeintastyDbConnection, IRestaurantOrderRepositoryAsync
    {
        public Task<GeneralResponse<RestaurantOrder>> AddAsync(RestaurantOrder request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<RestaurantOrder>> DeleteAsync(RestaurantOrder request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<RestaurantOrder>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<RestaurantOrder>>> GetAllByIdAsync(int id)
        {
            var data = new GeneralResponse<List<RestaurantOrder>>();
            data.Value = new List<RestaurantOrder>();
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
                var result = await connection.db.QueryAsync<RestaurantOrder>("sel_AllOrdersByRestaurantId", parameters, commandType: CommandType.StoredProcedure);
                data.Value = result.ToList();
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

        public Task<GeneralResponse<RestaurantOrder>> GetAsync(RestaurantOrder request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<RestaurantOrder>> UpdateAsync(RestaurantOrder request)
        {
            throw new NotImplementedException();
        }
    }
}
