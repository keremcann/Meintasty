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

            return await Task.FromResult(response);
        }
    }
}
