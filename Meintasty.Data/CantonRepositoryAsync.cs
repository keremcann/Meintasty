using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using Meintasty.Domain.Shared.Constants;
using System.Data;

namespace Meintasty.Data
{
    public class CantonRepositoryAsync : MeintastyDbConnection, ICantonRepositoryAsync
    {
        public Task<GeneralResponse<Canton>> AddAsync(Canton request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Canton>> DeleteAsync(Canton request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponse<List<Canton>>> GetAllAsync()
        {
            var data = new GeneralResponse<List<Canton>>();
            data.Value = new List<Canton>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection?.db?.QueryAsync<Canton>("sel_AllCantons", CommandType.StoredProcedure).Result.ToList();
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

        public Task<GeneralResponse<Canton>> GetAsync(Canton request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Canton>> UpdateAsync(Canton request)
        {
            throw new NotImplementedException();
        }
    }
}
