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

            var basket = await _basketRepository.DeleteAsync(new Domain.Entity.Basket 
            { 
                Id = request.BasketId,
                DeleteUser = 1,
                DeleteDate = DateTime.UtcNow,
                IsActive = false,
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
