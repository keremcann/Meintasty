using Dapper;
using Meintasty.Core.Common;
using Meintasty.Core.Connection;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using System.Data;

namespace Meintasty.Data
{
    public class RoleRepositoryAsync : MeintastyDbConnection, IRoleRepositoryAsync
    {
        public Task<GeneralResponse<Role>> AddAsync(Role request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Role>> DeleteAsync(Role request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<Role>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<Role>>> GetAllByIdAsync(int id)
        {
            var data = new GeneralResponse<List<Role>>();
            data.Value = new List<Role>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", id);

            try
            {
                data.Value = connection?.db?.QueryAsync<Role>("sel_UserRolesByUserId", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
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

        public Task<GeneralResponse<Role>> GetAsync(Role request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Role>> UpdateAsync(Role request)
        {
            throw new NotImplementedException();
        }
    }
}
