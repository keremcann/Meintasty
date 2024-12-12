using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Core.Log;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepositoryAsync : MeintastyDbConnection, IUserRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<GeneralResponse<User>> AddAsync(User request)
        {
            var data = new GeneralResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var user = connection?.db?.QueryAsync<Int32>("ins_NewUser", new
                {
                    request.FullName,
                    request.Email,
                    request.PhoneNumber,
                    request.Password,
                    request.CreateUser,
                    request.CreateDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Kullanıcı oluşturuldu!";
                data.Value.Id = user.Value;
                data.Value.FullName = request.FullName;
                data.Value.Email = request.Email;
                data.Value.PhoneNumber = request.PhoneNumber;

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
        /// <exception cref="NotImplementedException"></exception>
        public async Task<GeneralResponse<User>> DeleteAsync(User request)
        {
            var data = new GeneralResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", request.Id);

            try
            {
                var user = connection?.db?.QueryAsync<Int32>("del_User", parameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Operation finished successfully!";

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
        /// <exception cref="NotImplementedException"></exception>
        public Task<GeneralResponse<List<User>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<User>> GetAsync(User request)
        {
            var data = new GeneralResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection?.db?.QueryAsync<User>("sel_UserByInfo", new
                {
                    request.Email,
                    request.Password
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                if (data.Value != null)
                {
                    data.Success = true;
                    data.InfoMessage = "Kullanıcı bulundu";
                }
                else
                {
                    data.Success = false;
                    data.ErrorMessage = "Kullanıcı bulunamadı";
                }
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
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<User>> GetByIdAsync(int id)
        {
            var data = new GeneralResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", id);

                data.Value = connection?.db?.QueryAsync<User>("sel_UserById", parameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                if (data.Value != null)
                {
                    data.Success = true;
                    data.InfoMessage = "Kullanıcı bulundu";
                }
                else
                {
                    data.Success = false;
                    data.ErrorMessage = "Kullanıcı bulunamadı";
                }
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
        /// <exception cref="NotImplementedException"></exception>
        public async Task<GeneralResponse<User>> UpdateAsync(User request)
        {
            var data = new GeneralResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var user = connection?.db?.QueryAsync<Int32>("upd_UserInfo", new
                {
                    request.Id,
                    request.FullName,
                    request.Gender,
                    request.BirthDate,
                    request.UpdateUser,
                    request.UpdateDate,
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Operation finished successfully!";

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
        public async Task<GeneralResponse<bool>> UpdateUserEmailAsync(User request)
        {
            var data = new GeneralResponse<Boolean>();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var user = connection?.db?.QueryAsync<Int32>("upd_UserEmail", new
                {
                    request.Id,
                    request.Email,
                    request.UpdateUser,
                    request.UpdateDate,
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Operation finished successfully!";

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
        public async Task<GeneralResponse<bool>> UpdateUserPhoneAsync(User request)
        {
            var data = new GeneralResponse<Boolean>();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var user = connection?.db?.QueryAsync<Int32>("upd_UserPhoneNumber", new
                {
                    request.Id,
                    request.PhoneNumber,
                    request.UpdateUser,
                    request.UpdateDate,
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Operation finished successfully!";

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
        public async Task<GeneralResponse<bool>> UpdateUserPasswordAsync(User request)
        {
            var data = new GeneralResponse<Boolean>();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var user = connection?.db?.QueryAsync<Int32>("upd_UserPassword", new
                {
                    request.Id,
                    request.Password,
                    request.UpdateUser,
                    request.UpdateDate,
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Operation finished successfully!";

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
