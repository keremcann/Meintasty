using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Core.Log;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class BasketRepositoryAsync : MeintastyDbConnection, IBasketRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<Basket>> AddAsync(Basket request)
        {
            var data = new GeneralResponse<Basket>();
            data.Value = new Basket();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var basket = connection?.db?.QueryAsync<Int32>("ins_NewBasket", new
                {
                    request.UserId,
                    request.RestaurantId,
                    request.MenuId,
                    request.BasketDate,
                    request.Quantity,
                    request.Price,
                    request.CurrencyCode,
                    request.CreateUser,
                    request.CreateDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<Basket>> DeleteAsync(Basket request)
        {
            var data = new GeneralResponse<Basket>();
            data.Value = new Basket();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var basket = connection?.db?.QueryAsync<Int32>("del_BasketById", new
                {
                    request.Id,
                    request.DeleteUser,
                    request.DeleteDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Sepetten silindi!";

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
        public async Task<GeneralResponse<List<Basket>>> GetAllAsync()
        {
            var data = new GeneralResponse<List<Basket>>();
            data.Value = new List<Basket>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection?.db?.QueryAsync<Basket>("sel_AllBaskets", commandType: CommandType.StoredProcedure).Result.ToList();
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
        public async Task<GeneralResponse<List<Basket>>> GetAllByInfoAsync(Basket request)
        {
            var data = new GeneralResponse<List<Basket>>();
            data.Value = new List<Basket>();
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
                spName = "sel_BasketsByUserId";
                parameters.Add("@UserId", request.UserId);
            }
            else if (request.RestaurantId != default(int) && request.RestaurantId > 0)
            {
                spName = "sel_BasketsByRestaurantId";
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
                data.Value = connection?.db?.QueryAsync<Basket>(spName, parameters, commandType: CommandType.StoredProcedure).Result.ToList();
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
        public async Task<GeneralResponse<Basket>> GetAsync(Basket request)
        {
            var data = new GeneralResponse<Basket>();
            data.Value = new Basket();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var basket = connection?.db?.QueryAsync<Int32>("sel_BasketById", new
                {
                    request.Id
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Sepet item ok!";

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
        public async Task<GeneralResponse<Basket>> UpdateAsync(Basket request)
        {
            var data = new GeneralResponse<Basket>();
            data.Value = new Basket();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var basket = connection?.db?.QueryAsync<Int32>("upd_Basket", new
                {
                    request.UpdateUser,
                    request.UpdateDate
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Sepet güncellendi!";

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
