using MediatR;
using Meintasty.Application.Contract.Order.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Order
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, GeneralResponse<List<GetOrderQueryResponse>>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IOrderRepositoryAsync _orderRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderRepository"></param>
        public GetOrderQueryHandler(IOrderRepositoryAsync orderRepository)
        {
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

            return await Task.FromResult(response);
        }
    }
}
