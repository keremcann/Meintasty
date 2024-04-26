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

            return await Task.FromResult(response);
        }
    }
}
