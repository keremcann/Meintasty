using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Order.Queries;
using Meintasty.Core.Common;
using Meintasty.Core.Configuration;
using Meintasty.Domain.Repository;
using Meintasty.Domain.Shared.Globals;

namespace Meintasty.Application.Order
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, GeneralResponse<GetOrderQueryResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="orderRepository"></param>
        public GetOrderQueryHandler(IMapper mapper, IOrderRepositoryAsync orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<GetOrderQueryResponse>> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetOrderQueryResponse>();
            response.Value = new GetOrderQueryResponse();
            response.Value.Orders = new List<GetOrderQueryContract>();

            int pageSize = Convert.ToInt32(AppSettings.GetPageSize());
            int offset = (request.PageNumber - 1) * pageSize;

            Domain.Entity.Order order = new Domain.Entity.Order()
            {
                UserId = UserSettings.UserId,
                RestaurantId = UserSettings.RestId //request.RestaurantId ?? 0,
            };
            var orders = await _orderRepository.GetAllByInfoAsync(order, pageSize, offset);
            if (!orders.Success)
            {
                response.Success = orders.Success;
                response.ErrorMessage = orders.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (orders.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Sipariş yok!";
                return await Task.FromResult(response);
            }

            var itemCount = await _orderRepository.GetTotalCountAsync(UserSettings.UserId, request.RestaurantId ?? 0);
            if (!itemCount.Success)
            {
                response.Success = itemCount.Success;
                response.ErrorMessage = itemCount.ErrorMessage;
                return await Task.FromResult(response);
            }

            int totalCount = itemCount.Value;
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            int? prevPage = request.PageNumber > 1 ? (int?)(request.PageNumber - 1) : null;
            int? nextPage = request.PageNumber < totalPages ? (int?)(request.PageNumber + 1) : null;

            response.Success = true;
            response.InfoMessage = "Başarılı";
            response.Value.Orders = _mapper.Map<List<GetOrderQueryContract>>(orders.Value);
            response.Value.TotalCount = totalCount;
            response.Value.TotalPages = totalPages;
            response.Value.PrevPage = prevPage;
            response.Value.CurrentPage = request.PageNumber;
            response.Value.NextPage = nextPage;

            return await Task.FromResult(response);
        }
    }
}
