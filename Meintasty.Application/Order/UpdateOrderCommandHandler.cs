using MediatR;
using Meintasty.Application.Contract.Order.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Order
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, GeneralResponse<UpdateOrderCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IOrderRepositoryAsync _orderRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderRepository"></param>
        public UpdateOrderCommandHandler(IOrderRepositoryAsync orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<UpdateOrderCommandResponse>> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<UpdateOrderCommandResponse>();
            response.Value = new UpdateOrderCommandResponse();

            return await Task.FromResult(response);
        }
    }
}
