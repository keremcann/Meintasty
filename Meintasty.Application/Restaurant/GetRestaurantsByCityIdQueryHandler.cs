using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Restaurant.Queries;
using Meintasty.Core.Common;
using Meintasty.Core.Configuration;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Restaurant
{
    public class GetRestaurantsByCityIdQueryHandler : IRequestHandler<GetRestaurantsByCityIdQueryRequest, GeneralResponse<GetRestaurantsByCityIdQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepositoryAsync _restaurantRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="restaurantRepository"></param>
        public GetRestaurantsByCityIdQueryHandler(IMapper mapper, IRestaurantRepositoryAsync restaurantRepository)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<GetRestaurantsByCityIdQueryResponse>> Handle(GetRestaurantsByCityIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetRestaurantsByCityIdQueryResponse>();
            response.Value = new GetRestaurantsByCityIdQueryResponse();
            response.Value.Restaurants = new List<RestaurantsByCityIdContract>();
            
            if (request.IsPaging)
            {
                if (request.PageSize <= 0)
                {
                    request.PageSize = Convert.ToInt32(AppSettings.GetPageSize());
                }

                int offset = (request.PageNumber - 1) * request.PageSize;
                var restaurants = await _restaurantRepository.GetAllByCityIdWithPagingAsync(request.CityCode, request.PageSize, offset, request.CategoryIdList);

                if (!restaurants.Success)
                {
                    response.Success = restaurants.Success;
                    response.ErrorMessage = restaurants.ErrorMessage;
                    return await Task.FromResult(response);
                }
                if (restaurants.Value == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Not found any Restaurant!";
                    return await Task.FromResult(response);
                }

                var itemCount = await _restaurantRepository.GetTotalCountAsync(request.CityCode, request.CategoryIdList);
                if (!itemCount.Success)
                {
                    response.Success = itemCount.Success;
                    response.ErrorMessage = itemCount.ErrorMessage;
                    return await Task.FromResult(response);
                }

                int totalCount = itemCount.Value;
                int totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

                int? prevPage = request.PageNumber > 1 ? (int?)(request.PageNumber - 1) : null;
                int? nextPage = request.PageNumber < totalPages ? (int?)(request.PageNumber + 1) : null;

                response.Value.Restaurants = _mapper.Map<List<RestaurantsByCityIdContract>>(restaurants.Value);
                response.Value.TotalCount = totalCount;
                response.Value.TotalPages = totalPages;                
                response.Value.PrevPage = prevPage;
                response.Value.CurrentPage = request.PageNumber;
                response.Value.NextPage = nextPage;
                response.Success = true;
                response.InfoMessage = "Success";

                return await Task.FromResult(response);
            }
            else
            {
                var restaurants = await _restaurantRepository.GetAllByCityIdAsync(request.CityCode);

                if (!restaurants.Success)
                {
                    response.Success = restaurants.Success;
                    response.ErrorMessage = restaurants.ErrorMessage;
                    return await Task.FromResult(response);
                }
                if (restaurants.Value == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Not found any Restaurant!";
                    return await Task.FromResult(response);
                }

                response.Value.Restaurants = _mapper.Map<List<RestaurantsByCityIdContract>>(restaurants.Value);
                response.Success = true;
                response.InfoMessage = "Success";

                return await Task.FromResult(response);
            }
        }
    }
}
