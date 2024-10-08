using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class UserAddressRepositoryAsync : MeintastyDbConnection, IUserAddressRepositoryAsync
    {
        public Task<GeneralResponse<UserAddress>> AddAsync(UserAddress request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<UserAddress>> DeleteAsync(UserAddress request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<UserAddress>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<UserAddress>> GetAsync(UserAddress request)
        {
            var data = new GeneralResponse<UserAddress>();
            data.Value = new UserAddress();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", request.UserId);

            try
            {
                data.Value = connection?.db?.QueryAsync<UserAddress>("sel_DefaultAddressByUserId", parameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
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

        public Task<GeneralResponse<UserAddress>> UpdateAsync(UserAddress request)
        {
            throw new NotImplementedException();
        }
    }
}
