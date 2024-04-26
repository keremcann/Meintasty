using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class CityRepositoryAsync : MeintastyDbConnection, ICityRepositoryAsync
    {
        public Task<GeneralResponse<City>> AddAsync(City request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<City>> DeleteAsync(City request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponse<List<City>>> GetAllAsync()
        {
            var data = new GeneralResponse<List<City>>();
            data.Value = new List<City>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection?.db?.QueryAsync<City>("sel_AllCities", CommandType.StoredProcedure).Result.ToList();
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

        public Task<GeneralResponse<City>> GetAsync(City request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<City>> UpdateAsync(City request)
        {
            throw new NotImplementedException();
        }
    }
}
