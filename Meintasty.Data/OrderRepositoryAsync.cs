using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Core.Log;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class OrderRepositoryAsync : MeintastyDbConnection, IOrderRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<Order>> AddAsync(Order request)
        {
            var data = new GeneralResponse<Order>();
            data.Value = new Order();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var order = connection?.db?.QueryAsync<Int32>("ins_NewOrder", new
                {
                    request.UserId,
                    request.RestaurantId,
                    request.Name,
                    request.Price,
                    request.CurrencyCode,
                    request.PaymentType,
                    request.OrderTip,
                    request.CreateUser,
                    request.CreateDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Value.Id = order.Value;
                data.Success = true;
                data.InfoMessage = "Sipariş oluşturuldu!";

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
        public async Task<GeneralResponse<Order>> DeleteAsync(Order request)
        {
            var data = new GeneralResponse<Order>();
            data.Value = new Order();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var order = connection?.db?.QueryAsync<Int32>("del_OrderById", new
                {
                    request.Id,
                    request.DeleteUser,
                    request.DeleteDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Sipariş silindi!";

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
        /// <returns></returns>
        public async Task<GeneralResponse<List<Order>>> GetAllAsync()
        {
            var data = new GeneralResponse<List<Order>>();
            data.Value = new List<Order>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection?.db?.QueryAsync<Order>("sel_AllOrders", commandType: CommandType.StoredProcedure).Result.ToList();
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
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<Order>>> GetAllByInfoAsync(Order request)
        {
            var data = new GeneralResponse<List<Order>>();
            data.Value = new List<Order>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            string spName = string.Empty;
            var parameters = new DynamicParameters();

            if (request.UserId != default(int) && request.UserId > 0) 
            {
                spName = "sel_OrdersByUserId";
                parameters.Add("@UserId", request.UserId);
            }
            else if (request.RestaurantId != default(int) && request.RestaurantId > 0)
            {
                spName = "sel_OrdersByRestaurantId";
                parameters.Add("@RestaurantId", request.RestaurantId);
            }
            else
            {
                data.Success = false;
                data.ErrorMessage = "Kişi veya Restaurant boş olamaz!";
                connection?.db?.Close();
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection?.db?.QueryAsync<Order>(spName, parameters, commandType: CommandType.StoredProcedure).Result.ToList();
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
        public async Task<GeneralResponse<Order>> GetAsync(Order request)
        {
            var data = new GeneralResponse<Order>();
            data.Value = new Order();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var order = connection?.db?.QueryAsync<Int32>("sel_OrderById", new
                {
                    request.Id
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Sipariş güncellendi!";

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
        public async Task<GeneralResponse<Order>> UpdateAsync(Order request)
        {
            var data = new GeneralResponse<Order>();
            data.Value = new Order();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var order = connection?.db?.QueryAsync<Int32>("upd_Order", new
                {
                    request.Id,
                    request.UpdateUser,
                    request.UpdateDate
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Sipariş güncellendi!";

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
