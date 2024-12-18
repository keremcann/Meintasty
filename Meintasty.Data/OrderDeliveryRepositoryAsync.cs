using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Core.Log;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class OrderDeliveryRepositoryAsync : MeintastyDbConnection, IOrderDeliveryRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<OrderDelivery>> AddAsync(OrderDelivery request)
        {
            var data = new GeneralResponse<OrderDelivery>();
            data.Value = new OrderDelivery();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var delivery = await connection.db.QueryAsync<Int32>("ins_NewOrderDelivery", new
                {
                    request.OrderId,
                    request.Status,
                    request.Description,
                    request.CreateUser,
                    request.CreateDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure);

                data.Value.Id = delivery.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Teslimat oluşturuldu!";

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

        public Task<GeneralResponse<OrderDelivery>> DeleteAsync(OrderDelivery request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<OrderDelivery>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<OrderDelivery>> GetAsync(OrderDelivery request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<OrderDelivery>> UpdateAsync(OrderDelivery request)
        {
            throw new NotImplementedException();
        }
    }
}
