using Meintasty.Core.Common;
using Meintasty.Domain.Common;
using Meintasty.Domain.Entity;

namespace Meintasty.Domain.Repository
{
    public interface IRoleRepositoryAsync : IRepositoryAsync<Role>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GeneralResponse<List<Role>>> GetAllByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<GeneralResponse<Boolean>> AddUserRole(int userId, int roleId);
    }
}
