using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Home.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Home
{
    public class GetFavoriteRestaurantQueryHandler : IRequestHandler<GetFavoriteRestaurantQueryRequest, GeneralResponse<List<GetFavoriteRestaurantQueryResponse>>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IRestaurantRepositoryAsync _restaurantRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="restaurantRepository"></param>
        public GetFavoriteRestaurantQueryHandler(IMapper mapper, IRestaurantRepositoryAsync restaurantRepository)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
        }

        /// <summary>
        /// s
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<GetFavoriteRestaurantQueryResponse>>> Handle(GetFavoriteRestaurantQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetFavoriteRestaurantQueryResponse>>();
            response.Value = new List<GetFavoriteRestaurantQueryResponse>();

            var restaurants = await _restaurantRepository.GetFavoritesAsync();
            if (!restaurants.Success)
            {
                response.Success = restaurants.Success;
                response.ErrorMessage = restaurants.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Value = _mapper.Map<List<GetFavoriteRestaurantQueryResponse>>(restaurants.Value);
            response.Success = true;
            response.InfoMessage = "Success";

            return await Task.FromResult(response);
        }
    }
}
