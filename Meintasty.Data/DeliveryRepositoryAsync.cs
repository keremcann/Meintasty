using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Core.Log;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponse<List<Delivery>>> GetAllAsync()
        {
            var data = new GeneralResponse<List<Delivery>>();
            data.Value = new List<Delivery>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var result = await connection.db.QueryAsync<Delivery>("sel_AllDeliveries", commandType: CommandType.StoredProcedure);
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
        public async Task<GeneralResponse<Delivery>> GetAsync(Delivery request)
        {
            var data = new GeneralResponse<Delivery>();
            data.Value = new Delivery();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var basket = await connection.db.QueryAsync<Delivery>("sel_DeliveryById", new
                {
                    request.Id
                }, commandType: CommandType.StoredProcedure);

                data.Value = basket?.FirstOrDefault() ?? new Delivery();
                data.Success = true;
                data.InfoMessage = "Delivery item ok!";

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

        public Task<GeneralResponse<Delivery>> UpdateAsync(Delivery request)
        {
            throw new NotImplementedException();
        }
    }
}
