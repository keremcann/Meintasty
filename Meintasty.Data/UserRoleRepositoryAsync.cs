using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Core.Log;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class UserRoleRepositoryAsync : MeintastyDbConnection, IUserRoleRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<UserRole>> AddAsync(UserRole request)
        {
            var data = new GeneralResponse<UserRole>();
            data.Value = new UserRole();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var result = connection?.db?.QueryAsync<Int32>("ins_UserRole", new
                {
                    request.UserId,
                    request.RoleId,
                    request.CreateUser,
                    request.CreateDate,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Kullanıcı oluşturuldu!";

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

        public Task<GeneralResponse<UserRole>> DeleteAsync(UserRole request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<UserRole>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<UserRole>> GetAsync(UserRole request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<UserRole>> UpdateAsync(UserRole request)
        {
            throw new NotImplementedException();
        }
    }
}
