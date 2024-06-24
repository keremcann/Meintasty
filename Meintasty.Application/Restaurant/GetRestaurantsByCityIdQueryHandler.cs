using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Restaurant.Queries;
using Meintasty.Core.Common;
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

            var restaurants = _restaurantRepository.GetAllByIdAsync(request.CityCode);

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
