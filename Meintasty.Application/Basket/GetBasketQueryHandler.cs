using MediatR;
using Meintasty.Application.Contract.Basket.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Basket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQueryRequest, GeneralResponse<List<GetBasketQueryResponse>>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBasketRepositoryAsync _basketRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketRepository"></param>
        public GetBasketQueryHandler(IBasketRepositoryAsync basketRepository)
        {
            _basketRepository = basketRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<GetBasketQueryResponse>>> Handle(GetBasketQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetBasketQueryResponse>>();
            response.Value = new List<GetBasketQueryResponse>();

            return await Task.FromResult(response);
        }
    }
}
