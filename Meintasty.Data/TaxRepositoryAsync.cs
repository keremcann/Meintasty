using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Core.Log;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponse<List<Tax>>> GetAllAsync()
        {
            var data = new GeneralResponse<List<Tax>>();
            data.Value = new List<Tax>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var result = await connection.db.QueryAsync<Tax>("sel_AllTaxes", commandType: CommandType.StoredProcedure);
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
        public async Task<GeneralResponse<Tax>> GetAsync(Tax request)
        {
            var data = new GeneralResponse<Tax>();
            data.Value = new Tax();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var basket = await connection.db.QueryAsync<Tax>("sel_TaxById", new
                {
                    request.Id
                }, commandType: CommandType.StoredProcedure);

                data.Value = basket?.FirstOrDefault() ?? new Tax();
                data.Success = true;
                data.InfoMessage = "Tax item ok!";

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

        public Task<GeneralResponse<Tax>> UpdateAsync(Tax request)
        {
            throw new NotImplementedException();
        }
    }
}
