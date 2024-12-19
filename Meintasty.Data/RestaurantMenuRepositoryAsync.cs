using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Core.Log;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class RestaurantMenuRepositoryAsync : MeintastyDbConnection, IRestaurantMenuRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<RestaurantMenu>> AddAsync(RestaurantMenu request)
        {
            var data = new GeneralResponse<RestaurantMenu>();
            data.Value = new RestaurantMenu();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var result = await connection.db.QueryAsync<Int32>("ins_NewRestaurantMenu", new
                {
                    request.RestaurantId,
                    request.CategoryId,
                    request.MenuName,
                    request.MenuPic,
                    request.MenuContent,
                    request.MenuPrice,
                    request.Currency,
                    request.CreateUser,
                    request.CreateDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure);

                data.Value.Id = result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Menü eklendi!";

                connection?.db?.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                FileLog log = new FileLog();
                log.Error(ex.Message);
                connection?.db?.Close();
                return await Task.FromResult(data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<RestaurantMenu>> DeleteAsync(RestaurantMenu request)
        {
            var data = new GeneralResponse<RestaurantMenu>();
            data.Value = new RestaurantMenu();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var result = await connection.db.QueryAsync<Int32>("del_RestaurantMenu", new
                {
                    request.Id,
                    request.DeleteUser,
                    request.DeleteDate
                }, commandType: CommandType.StoredProcedure);

                data.Value.Id = result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Menü silindi!";

                connection?.db?.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                FileLog log = new FileLog();
                log.Error(ex.Message);
                connection?.db?.Close();
                return await Task.FromResult(data);
            }
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
                var result = await connection.db.QueryAsync<RestaurantMenu>("sel_MenuByRestaurantId", parameters, commandType: CommandType.StoredProcedure);
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
                data.Value = connection.db.QueryAsync<RestaurantMenu>("sel_FavoriteMenus", commandType: CommandType.StoredProcedure).Result.ToList();
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
        public async Task<GeneralResponse<RestaurantMenu>> UpdateAsync(RestaurantMenu request)
        {
            var data = new GeneralResponse<RestaurantMenu>();
            data.Value = new RestaurantMenu();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var result = await connection.db.QueryAsync<Int32>("upd_RestaurantMenuById", new
                {
                    request.Id,
                    request.RestaurantId,
                    request.CategoryId,
                    request.MenuName,
                    request.MenuPic,
                    request.MenuContent,
                    request.MenuPrice,
                    request.Currency,
                    request.UpdateUser,
                    request.UpdateDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure);

                data.Value.Id = result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Menü güncellendi!";

                connection?.db?.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                FileLog log = new FileLog();
                log.Error(ex.Message);
                connection?.db?.Close();
                return await Task.FromResult(data);
            }
        }
    }
}
