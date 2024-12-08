using MediatR;
using Meintasty.Application.Contract.Order.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;
using Meintasty.Domain.Shared.Globals;

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
                UserId = UserSettings.UserId, //request.UserId,
                RestaurantId = request.RestaurantId,
                Name = UserSettings.UserId + "-" + request.RestaurantId + "-Order-" + DateTime.Now.ToString(),
                Price = request.Price,
                CurrencyCode = request.CurrencyCode ?? "EUR",
                PaymentType = request.PaymentType,
                OrderTip = request.OrderTip ?? "0",
                OrderStatus = "Pending",
                CreateDate = DateTime.UtcNow,
                CreateUser = UserSettings.UserId, //1,
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
