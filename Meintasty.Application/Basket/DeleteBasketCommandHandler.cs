using MediatR;
using Meintasty.Application.Contract.Basket.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Basket
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, GeneralResponse<DeleteBasketCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBasketRepositoryAsync _basketRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketRepository"></param>
        public DeleteBasketCommandHandler(IBasketRepositoryAsync basketRepository)
        {
            _basketRepository = basketRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<DeleteBasketCommandResponse>> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<DeleteBasketCommandResponse>();
            response.Value = new DeleteBasketCommandResponse();

            return await Task.FromResult(response);
        }
    }
}
