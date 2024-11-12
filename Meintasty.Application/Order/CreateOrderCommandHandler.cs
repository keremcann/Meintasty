using MediatR;
using Meintasty.Application.Contract.Order.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Order
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, GeneralResponse<CreateOrderCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IOrderRepositoryAsync _orderRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderRepository"></param>
        public CreateOrderCommandHandler(IOrderRepositoryAsync orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<CreateOrderCommandResponse>> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateOrderCommandResponse>();
            response.Value = new CreateOrderCommandResponse();

            var order = await _orderRepository.AddAsync(new Domain.Entity.Order
            {
                UserId = request.UserId,
                RestaurantId = request.RestaurantId,
                Name = request.UserId + "-" + request.RestaurantId + "-Order-" + DateTime.Now.ToString(),
                OrderDate = request.OrderDate,
                Price = request.Price,
                CurrencyCode = request.CurrencyCode ?? "EUR",
                PaymentType = request.PaymentType,
                OrderTip = request.OrderTip ?? "0",
                CreateDate = DateTime.UtcNow,
                CreateUser = 1,
                IsActive = true,
            });

            if (!order.Success)
            {
                response.Success = order.Success;
                response.ErrorMessage = order.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Başarılı";

            return await Task.FromResult(response);
        }
    }
}
