using MediatR;
using Meintasty.Application.Contract.Basket.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Basket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest, GeneralResponse<CreateBasketCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBasketRepositoryAsync _basketRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketRepository"></param>
        public CreateBasketCommandHandler(IBasketRepositoryAsync basketRepository)
        {
            _basketRepository = basketRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<CreateBasketCommandResponse>> Handle(CreateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateBasketCommandResponse>();
            response.Value = new CreateBasketCommandResponse();

            var basket = await _basketRepository.AddAsync(new Domain.Entity.Basket
            {
                UserId = request.UserId,
                RestaurantId = request.RestaurantId,
                MenuId = request.MenuId,
                Quantity = request.Quantity,
                Price = request.Price.ToString(),
                CurrencyCode = request.CurrencyCode ?? "EUR",
                BasketDate = DateTime.UtcNow,
                CreateDate = DateTime.UtcNow,
                CreateUser = 1,
                IsActive = true,
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
