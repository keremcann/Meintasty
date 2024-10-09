using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Basket.Commands;
using Meintasty.Application.Contract.Category.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Category
{
    public class GetCategoryRestaurantQueryHandler : IRequestHandler<GetCategoryRestaurantQueryRequest, GeneralResponse<List<GetCategoryRestaurantQueryResponse>>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IRestaurantRepositoryAsync _restaurantRepository;
        private readonly ICategoryRepositoryAsync _categoryRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="restaurantRepository"></param>
        /// <param name="categoryRepository"></param>
        public GetCategoryRestaurantQueryHandler(IMapper mapper,IRestaurantRepositoryAsync restaurantRepository, ICategoryRepositoryAsync categoryRepository)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _categoryRepository = categoryRepository;

        }
        public async Task<GeneralResponse<List<GetCategoryRestaurantQueryResponse>>> Handle(GetCategoryRestaurantQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetCategoryRestaurantQueryResponse>>();
            response.Value = new List<GetCategoryRestaurantQueryResponse>();

            var restaurants = await _restaurantRepository.GetAllByCategoryIdAsync(request.CategoryId);
            if (!restaurants.Success)
            {
                response.Success = restaurants.Success;
                response.ErrorMessage = restaurants.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Value = _mapper.Map<List<GetCategoryRestaurantQueryResponse>>(restaurants.Value);

            if (restaurants.Value != null && restaurants.Value.Count > 0)
            {
                foreach (var item in restaurants.Value)
                {
                    var categories = await _categoryRepository.GetAllByIdAsync(item.Id);
                    if (!categories.Success)
                    {
                        response.Success = categories.Success;
                        response.ErrorMessage = categories.ErrorMessage;
                        return await Task.FromResult(response);
                    }
                    var categoryList = _mapper.Map<List<GetCategoryQueryResponse>>(categories.Value);
                    response.Value.First(x => x.Id == item.Id).Categories.AddRange(categoryList);
                    Random random = new Random();
                    response.Value.First(x => x.Id == item.Id).StarCount = random.Next(1, 6);
                    response.Value.First(x => x.Id == item.Id).MinTime = random.Next(20, 50);
                    response.Value.First(x => x.Id == item.Id).CurrencyCode = "EUR";
                    response.Value.First(x => x.Id == item.Id).Delivery = "FREE";
                    response.Value.First(x => x.Id == item.Id).MinBudget = random.Next(3, 11).ToString();
                }
            }

            response.Success = true;
            response.InfoMessage = "Başarılı";

            return await Task.FromResult(response);
        }
    }
}
