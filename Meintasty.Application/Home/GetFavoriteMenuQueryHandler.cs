using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Home.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Home
{
    public class GetFavoriteMenuQueryHandler : IRequestHandler<GetFavoriteMenuQueryRequest, GeneralResponse<List<GetFavoriteMenuQueryResponse>>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IRestaurantMenuRepositoryAsync _restaurantMenuRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="restaurantMenuRepository"></param>
        public GetFavoriteMenuQueryHandler(IMapper mapper, IRestaurantMenuRepositoryAsync restaurantMenuRepository)
        {
            _mapper = mapper;
            _restaurantMenuRepository = restaurantMenuRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<GetFavoriteMenuQueryResponse>>> Handle(GetFavoriteMenuQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetFavoriteMenuQueryResponse>>();
            response.Value = new List<GetFavoriteMenuQueryResponse>();

            var menus = await _restaurantMenuRepository.GetFavoritesAsync();
            if (!menus.Success)
            {
                response.Success = menus.Success;
                response.ErrorMessage = menus.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Value = _mapper.Map<List<GetFavoriteMenuQueryResponse>>(menus.Value);
            response.Success = true;
            response.InfoMessage = "Success";

            return await Task.FromResult(response);
        }
    }
}
