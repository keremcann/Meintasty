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
                data.Value = connection?.db?.QueryAsync<Restaurant>("sel_AllRestaurants", CommandType.StoredProcedure).Result.ToList();
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
        public async Task<GeneralResponse<List<Restaurant>>> GetAllByIdAsync(int id)
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
                data.Value = connection?.db?.QueryAsync<Restaurant>("sel_AllRestaurantsByCityId", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
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

        public Task<GeneralResponse<Restaurant>> GetAsync(Restaurant request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Restaurant>> UpdateAsync(Restaurant request)
        {
            throw new NotImplementedException();
        }
    }
}
