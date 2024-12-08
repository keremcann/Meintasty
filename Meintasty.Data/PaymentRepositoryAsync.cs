using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Core.Log;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using Meintasty.Domain.Shared.Constants;
using System.Data;

namespace Meintasty.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class PaymentRepositoryAsync : MeintastyDbConnection, IPaymentRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<Payment>> AddAsync(Payment request)
        {
            var data = new GeneralResponse<Payment>();
            data.Value = new Payment();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var payment =  await connection.db.QueryAsync<Int32>("ins_NewPayment", new
                {
                    request.UserId,
                    request.OrderId,
                    request.TransactionId,
                    request.Description,
                    request.Amount,
                    request.Currency,
                    request.PaymentType,
                    request.PaymentStatus,
                    request.CreateUser,
                    request.CreateDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure);

                data.Value.Id = payment.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Sepete eklendi!";

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

        public Task<GeneralResponse<Payment>> DeleteAsync(Payment request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponse<List<Payment>>> GetAllAsync()
        {
            var data = new GeneralResponse<List<Payment>>();
            data.Value = new List<Payment>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var result = await connection.db.QueryAsync<Payment>("sel_AllBaskets", commandType: CommandType.StoredProcedure);
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

        public async Task<GeneralResponse<Payment>> GetAsync(Payment request)
        {
            var data = new GeneralResponse<Payment>();
            data.Value = new Payment();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var payment = await connection.db.QueryAsync<Payment>("sel_PaymentById", new
                {
                    request.Id
                }, commandType: CommandType.StoredProcedure);
                data.Value = payment.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Payment item ok!";

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
        public async Task<GeneralResponse<Payment>> UpdateAsync(Payment request)
        {
            var data = new GeneralResponse<Payment>();
            data.Value = new Payment();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var payment = await connection.db.QueryAsync<Int32>("upd_Payment", new
                {
                    request.UserId,
                    request.OrderId,
                    request.TransactionId,
                    request.Description,
                    request.Amount,
                    request.Currency,
                    request.PaymentType,
                    request.PaymentStatus,
                    request.CreateUser,
                    request.CreateDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure);

                data.Value.Id = payment.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Sepete eklendi!";

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
