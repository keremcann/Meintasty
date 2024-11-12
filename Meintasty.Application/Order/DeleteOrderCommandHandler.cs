using MediatR;
using Meintasty.Application.Contract.Order.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Order
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, GeneralResponse<DeleteOrderCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IOrderRepositoryAsync _orderRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderRepository"></param>
        public DeleteOrderCommandHandler(IOrderRepositoryAsync orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<DeleteOrderCommandResponse>> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<DeleteOrderCommandResponse>();
            response.Value = new DeleteOrderCommandResponse();

            var order = await _orderRepository.DeleteAsync(new Domain.Entity.Order
            {
                Id = request.OrderId,
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
