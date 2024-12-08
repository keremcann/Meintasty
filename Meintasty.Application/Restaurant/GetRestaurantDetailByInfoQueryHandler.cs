using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Restaurant;
using Meintasty.Application.Contract.Restaurant.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Restaurant
{
    public class GetRestaurantDetailByInfoQueryHandler : IRequestHandler<GetRestaurantDetailByInfoQueryRequest, GeneralResponse<GetRestaurantDetailByInfoQueryResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IRestaurantRepositoryAsync _restaurantRepository;
        private readonly IRestaurantAddressRepositoryAsync _restaurantAddressRepository;
        private readonly IRestaurantMenuRepositoryAsync _restaurantMenuRepository;
        private readonly IRestaurantOrderRepositoryAsync _restaurantOrderRepository;

        /// <summary>
        /// 
        /// </summary>
        public GetRestaurantDetailByInfoQueryHandler(IMapper mapper, IRestaurantRepositoryAsync restaurantRepository, IRestaurantAddressRepositoryAsync restaurantAddressRepository, IRestaurantMenuRepositoryAsync restaurantMenuRepository, IRestaurantOrderRepositoryAsync restaurantOrderRepository)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _restaurantAddressRepository = restaurantAddressRepository;
            _restaurantMenuRepository = restaurantMenuRepository;
            _restaurantOrderRepository = restaurantOrderRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<GeneralResponse<GetRestaurantDetailByInfoQueryResponse>> Handle(GetRestaurantDetailByInfoQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetRestaurantDetailByInfoQueryResponse>();
            response.Value = new GetRestaurantDetailByInfoQueryResponse();
            response.Value.AddressList = new List<RestaurantAddressContract>();
            response.Value.MenuList = new List<RestaurantMenuContract>();
            response.Value.OrderList = new List<RestaurantOrderContract>();

            #region Restaurant Info
            var restaurant = await _restaurantRepository.GetRestaurantDetailByInfoAsync(request.Url ?? "");
            if (!restaurant.Success)
            {
                response.Success = restaurant.Success;
                response.ErrorMessage = restaurant.ErrorMessage;
                return await Task.FromResult(response);
            }
            #endregion

            #region Restaurant Address Info
            var addressList = await _restaurantAddressRepository.GetAllByIdAsync(restaurant.Value.Id);
            if (!addressList.Success)
            {
                response.Success = addressList.Success;
                response.ErrorMessage = addressList.ErrorMessage;
                return await Task.FromResult(response);
            }
            #endregion

            #region Restaurant Menu Info
            var menuList = await _restaurantMenuRepository.GetAllByIdAsync(restaurant.Value.Id);
            if (!menuList.Success)
            {
                response.Success = menuList.Success;
                response.ErrorMessage = menuList.ErrorMessage;
                return await Task.FromResult(response);
            }
            #endregion

            #region Restaurant Order Info
            var orderList = await _restaurantOrderRepository.GetAllByIdAsync(restaurant.Value.Id);
            if (!orderList.Success)
            {
                response.Success = orderList.Success;
                response.ErrorMessage = orderList.ErrorMessage;
                return await Task.FromResult(response);
            }
            #endregion

            #region Mapper Objects            
            response.Value = _mapper.Map<GetRestaurantDetailByInfoQueryResponse>(restaurant.Value);
            response.Value.AddressList = _mapper.Map<List<RestaurantAddressContract>>(addressList.Value);
            response.Value.MenuList = _mapper.Map<List<RestaurantMenuContract>>(menuList.Value);
            response.Value.OrderList = _mapper.Map<List<RestaurantOrderContract>>(orderList.Value);
            response.Value.RestaurantId = restaurant.Value.Id;
            #endregion

            response.Success = true;
            response.InfoMessage = "Success";

            return await Task.FromResult(response);
        }
    }
}
