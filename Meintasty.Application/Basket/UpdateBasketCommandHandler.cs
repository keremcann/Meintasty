using MediatR;
using Meintasty.Application.Contract.Basket.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Basket
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest, GeneralResponse<UpdateBasketCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBasketRepositoryAsync _basketRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketRepository"></param>
        public UpdateBasketCommandHandler(IBasketRepositoryAsync basketRepository)
        {
            _basketRepository = basketRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<UpdateBasketCommandResponse>> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<UpdateBasketCommandResponse>();
            response.Value = new UpdateBasketCommandResponse();

            var basket = await _basketRepository.UpdateAsync(new Domain.Entity.Basket
            {
                Id = request.BasketId,
                Quantity = request.Quantity,
                UpdateDate = DateTime.UtcNow,
                UpdateUser = 1
            });

            if (!basket.Success)
            {
                response.Success = basket.Success;
                response.ErrorMessage = basket.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Başarılı";

            return await Task.FromResult(response);
        }
    }
}
