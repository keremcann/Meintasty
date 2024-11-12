using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Basket.Queries;
using Meintasty.Application.Contract.Order.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Order
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, GeneralResponse<List<GetOrderQueryResponse>>>
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
        public async Task<GeneralResponse<List<GetOrderQueryResponse>>> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetOrderQueryResponse>>();
            response.Value = new List<GetOrderQueryResponse>();

            var orders = await _orderRepository.GetAllByInfoAsync(new Domain.Entity.Order
            {
                UserId = request.UserId,
                RestaurantId = request.RestaurantId,
            });

            if (!orders.Success)
            {
                response.Success = orders.Success;
                response.ErrorMessage = orders.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (orders.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Sepet boş!";
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Başarılı";
            response.Value = _mapper.Map<List<GetOrderQueryResponse>>(orders.Value);

            return await Task.FromResult(response);
        }
    }
}
