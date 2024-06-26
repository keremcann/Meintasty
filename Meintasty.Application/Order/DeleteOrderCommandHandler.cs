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

            return await Task.FromResult(response);
        }
    }
}
