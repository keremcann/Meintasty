using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class RestaurantMenuRepositoryAsync : MeintastyDbConnection, IRestaurantMenuRepositoryAsync
    {
        public Task<GeneralResponse<RestaurantMenu>> AddAsync(RestaurantMenu request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<RestaurantMenu>> DeleteAsync(RestaurantMenu request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<RestaurantMenu>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<RestaurantMenu>>> GetAllByIdAsync(int id)
        {
            var data = new GeneralResponse<List<RestaurantMenu>>();
            data.Value = new List<RestaurantMenu>();
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
                data.Value = connection?.db?.QueryAsync<RestaurantMenu>("sel_MenuByRestaurantId", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<RestaurantMenu>> GetAsync(RestaurantMenu request)
        {
            var data = new GeneralResponse<RestaurantMenu>();
            data.Value = new RestaurantMenu();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@MenuId", request.RestaurantId);

            try
            {
                data.Value = connection?.db?.QueryAsync<RestaurantMenu>("sel_MenuById", parameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponse<List<RestaurantMenu>>> GetFavoritesAsync()
        {
            var data = new GeneralResponse<List<RestaurantMenu>>();
            data.Value = new List<RestaurantMenu>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }


            try
            {
                data.Value = connection?.db?.QueryAsync<RestaurantMenu>("sel_FavoriteMenus", commandType: CommandType.StoredProcedure).Result.ToList();
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

        public Task<GeneralResponse<RestaurantMenu>> UpdateAsync(RestaurantMenu request)
        {
            throw new NotImplementedException();
        }
    }
}
