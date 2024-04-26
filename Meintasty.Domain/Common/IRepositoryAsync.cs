using Meintasty.Core.Common;

namespace Meintasty.Domain.Common
{
    public interface IRepositoryAsync<T>
    {
        #region Async Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<GeneralResponse<List<T>>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GeneralResponse<T>> GetAsync(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GeneralResponse<T>> AddAsync(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GeneralResponse<T>> UpdateAsync(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GeneralResponse<T>> DeleteAsync(T request);

        #endregion
    }
}
