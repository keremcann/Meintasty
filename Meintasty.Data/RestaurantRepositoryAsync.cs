﻿using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class RestaurantRepositoryAsync : MeintastyDbConnection, IRestaurantRepositoryAsync
    {
        public Task<GeneralResponse<Restaurant>> AddAsync(Restaurant request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Restaurant>> DeleteAsync(Restaurant request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponse<List<Restaurant>>> GetAllAsync()
        {
            var data = new GeneralResponse<List<Restaurant>>();
            data.Value = new List<Restaurant>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var result = await connection.db.QueryAsync<Restaurant>("sel_AllRestaurants", CommandType.StoredProcedure);
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
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<Restaurant>>> GetAllByCategoryIdAsync(int id)
        {
            var data = new GeneralResponse<List<Restaurant>>();
            data.Value = new List<Restaurant>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);

            try
            {
                data.Value = connection?.db?.QueryAsync<Restaurant>("sel_AllRestaurantsByCategoryId", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
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
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<Restaurant>>> GetAllByCityIdAsync(int id)
        {
            var data = new GeneralResponse<List<Restaurant>>();
            data.Value = new List<Restaurant>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@CityCode", id);

            try
            {
                var result = await connection.db.QueryAsync<Restaurant>("sel_AllRestaurantsByCityId", parameters, commandType: CommandType.StoredProcedure);
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
        /// <param name="cityId"></param>
        /// <param name="pageSize"></param>
        /// <param name="offset"></param>
        /// <param name="categoryIdList"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<Restaurant>>> GetAllByCityIdWithPagingAsync(int cityId, int pageSize, int offset, List<int>? categoryIdList)
        {
            var data = new GeneralResponse<List<Restaurant>>();
            data.Value = new List<Restaurant>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            string spName = string.Empty;
            var parameters = new DynamicParameters();
            parameters.Add("@CityCode", cityId);
            parameters.Add("@PageSize", pageSize);
            parameters.Add("@Offset", offset);

            if (categoryIdList != null && categoryIdList.Count > 0)
            {
                var idTable = new DataTable();
                idTable.Columns.Add("Id", typeof(int));

                foreach (var id in categoryIdList)
                {
                    idTable.Rows.Add(id);
                }

                parameters.Add("@Ids", idTable.AsTableValuedParameter("IntListType"));
                spName = "sel_RestaurantsByFilter";
            }
            else
            {
                spName = "sel_RestaurantsByCityId";
            }            

            try
            {
                var result = await connection.db.QueryAsync<Restaurant>(spName, parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<GeneralResponse<Restaurant>> GetAsync(Restaurant request)
        {
            var data = new GeneralResponse<Restaurant>();
            data.Value = new Restaurant();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@RestaurantId", request.Id);

            try
            {
                var result = await connection.db.QueryAsync<Restaurant>("sel_RestaurantById", parameters, commandType: CommandType.StoredProcedure);
                data.Value = result?.FirstOrDefault();
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
        public async Task<GeneralResponse<List<Restaurant>>> GetFavoritesAsync()
        {
            var data = new GeneralResponse<List<Restaurant>>();
            data.Value = new List<Restaurant>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var result = await connection.db.QueryAsync<Restaurant>("sel_FavotireRestaurants", CommandType.StoredProcedure);
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
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<Restaurant>> GetRestaurantByInfoAsync(string email, string password)
        {
            var data = new GeneralResponse<Restaurant>();
            data.Value = new Restaurant();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);
            parameters.Add("Password", password);

            try
            {
                var result = await connection.db.QueryAsync<Restaurant>("sel_RestaurantByLoginInfo", parameters, commandType: CommandType.StoredProcedure);
                data.Value = result.FirstOrDefault();
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
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<Restaurant>> GetRestaurantDetailByInfoAsync(string url)
        {
            var data = new GeneralResponse<Restaurant>();
            data.Value = new Restaurant();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@Url", url);

            try
            {
                var result = await connection.db.QueryAsync<Restaurant>("sel_RestaurantByUrl", parameters, commandType: CommandType.StoredProcedure);
                data.Value = result?.FirstOrDefault();
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
        /// <param name="cityId"></param>
        /// <param name="categoryIdList"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<Int32>> GetTotalCountAsync(int cityId, List<int>? categoryIdList)
        {
            var data = new GeneralResponse<Int32>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }
            
            string spName = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@CityCode", cityId);

            if (categoryIdList != null && categoryIdList.Count > 0)
            {
                var idTable = new DataTable();
                idTable.Columns.Add("Id", typeof(int));

                foreach (var id in categoryIdList)
                {
                    idTable.Rows.Add(id);
                }

                parameters.Add("@Ids", idTable.AsTableValuedParameter("IntListType"));
                spName = "sel_RestaurantCountByFilter";
            }
            else
            {
                spName = "sel_RestaurantCount";
            }

            try
            {
                var result = await connection.db.QueryAsync<Int32>(spName, parameters, commandType: CommandType.StoredProcedure);
                data.Value = result.FirstOrDefault();
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

        public Task<GeneralResponse<Restaurant>> UpdateAsync(Restaurant request)
        {
            throw new NotImplementedException();
        }
    }
}
