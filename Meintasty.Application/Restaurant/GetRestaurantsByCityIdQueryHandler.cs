using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Restaurant.Queries;
using Meintasty.Core.Common;
using Meintasty.Core.Configuration;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Restaurant
{
    public class GetRestaurantsByCityIdQueryHandler : IRequestHandler<GetRestaurantsByCityIdQueryRequest, GeneralResponse<List<GetRestaurantsByCityIdQueryResponse>>>
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
        public async Task<GeneralResponse<List<GetRestaurantsByCityIdQueryResponse>>> Handle(GetRestaurantsByCityIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetRestaurantsByCityIdQueryResponse>>();
            response.Value = new List<GetRestaurantsByCityIdQueryResponse>();
            
            if (request.IsPaging)
            {
                if (request.PageSize <= 0)
                {
                    request.PageSize = Convert.ToInt32(AppSettings.GetPageSize());
                }

                int offset = (request.PageNumber - 1) * request.PageSize;
                var restaurants = await _restaurantRepository.GetAllByCityIdWithPagingAsync(request.CityCode, request.PageSize, offset, request.CategoryId);

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

                response.Value = _mapper.Map<List<GetRestaurantsByCityIdQueryResponse>>(restaurants.Value);
                response.Success = true;
                response.InfoMessage = "Success";

                return await Task.FromResult(response);
            }
            else
            {
                var restaurants = _restaurantRepository.GetAllByCityIdAsync(request.CityCode);

                if (!restaurants.Result.Success)
                {
                    response.Success = restaurants.Result.Success;
                    response.ErrorMessage = restaurants.Result.ErrorMessage;
                    return await Task.FromResult(response);
                }
                if (restaurants.Result.Value == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Not found any Restaurant!";
                    return await Task.FromResult(response);
                }

                response.Value = _mapper.Map<List<GetRestaurantsByCityIdQueryResponse>>(restaurants.Result.Value);
                response.Success = true;
                response.InfoMessage = "Success";

                return await Task.FromResult(response);
            }
        }
    }
}
