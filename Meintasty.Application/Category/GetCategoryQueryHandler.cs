using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Category.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Category
{
    internal class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, GeneralResponse<List<GetCategoryQueryResponse>>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly ICategoryRepositoryAsync _categoryRepositoryAsync;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="categoryRepositoryAsync"></param>
        public GetCategoryQueryHandler(IMapper mapper, ICategoryRepositoryAsync categoryRepositoryAsync)
        {
            _mapper = mapper;
            _categoryRepositoryAsync = categoryRepositoryAsync;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<GetCategoryQueryResponse>>> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetCategoryQueryResponse>>();
            response.Value = new List<GetCategoryQueryResponse>();

            var categories = await _categoryRepositoryAsync.GetAllAsync();
            if (!categories.Success)
            {
                response.Success = categories.Success;
                response.ErrorMessage = categories.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Value = _mapper.Map<List<GetCategoryQueryResponse>>(categories.Value);
            response.Success = true;
            response.InfoMessage = "Operation finished successfully!";

            return await Task.FromResult(response);
        }
    }
}
