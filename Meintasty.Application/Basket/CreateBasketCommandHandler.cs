using MediatR;
using Meintasty.Application.Contract.Basket.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using Meintasty.Domain.Shared.Globals;
using System.Globalization;

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

            var basketControl = await _basketRepository.GetAllByInfoAsync(new Domain.Entity.Basket
            {
                UserId = UserSettings.UserId,
            });
            if (!basketControl.Success)
            {
                response.Success = basketControl.Success;
                response.ErrorMessage = basketControl.ErrorMessage;
                return await Task.FromResult(response);
            }

            if (basketControl.Value != null && basketControl.Value.Count > 0)
            {
                if (request.IsReplaceBasket == null || request.IsReplaceBasket == false)
                {
                    response.Success = true;
                    response.InfoMessage = "Not replaced basket!";
                    return await Task.FromResult(response);
                }
                else
                {
                    var removeBasket = await _basketRepository.DeleteAllByUserIdAsync(UserSettings.UserId);
                    if (!removeBasket.Success)
                    {
                        response.Success = removeBasket.Success;
                        response.ErrorMessage = removeBasket.ErrorMessage;
                        return await Task.FromResult(response);
                    }
                    var addBasket = await _basketRepository.AddAsync(new Domain.Entity.Basket
                    {
                        UserId = UserSettings.UserId,
                        RestaurantId = request.RestaurantId,
                        MenuId = request.MenuId,
                        Quantity = request.Quantity ?? 1,
                        Price = request.Price,
                        CurrencyCode = request.CurrencyCode ?? "CHF",
                        BasketDate = DateTime.UtcNow,
                        CreateDate = DateTime.UtcNow,
                        CreateUser = 1,
                        IsActive = true,
                    });

                    if (!addBasket.Success)
                    {
                        response.Success = addBasket.Success;
                        response.ErrorMessage = addBasket.ErrorMessage;
                        return await Task.FromResult(response);
                    }

                    response.Success = true;
                    response.InfoMessage = "Başarılı";
                }
                var basket = await _basketRepository.GetAsync(new Domain.Entity.Basket 
                { 
                    MenuId = request.MenuId, 
                    UserId = UserSettings.UserId
                });
                if (!basket.Success)
                {
                    response.Success = basket.Success;
                    response.ErrorMessage = basket.ErrorMessage;
                    return await Task.FromResult(response);
                }
                if (request.Quantity == 1)
                {
                    var culture = new CultureInfo("tr-TR");
                    double dbPrice = double.Parse(basket.Value.Price ?? "0.00", CultureInfo.InvariantCulture);
                    double reqPrice = double.Parse(request.Price ?? "0.00", CultureInfo.InvariantCulture);
                    double sumPrice = dbPrice + reqPrice;
                    string price = sumPrice.ToString("N", culture);
                    price = price.Replace(",", ".");
                    var basketUpdate = await _basketRepository.UpdateAsync(new Domain.Entity.Basket
                    {
                        MenuId = request.MenuId,
                        Quantity = basket.Value.Quantity + 1,
                        Price = price,
                        UserId = UserSettings.UserId,
                    });
                    if (!basketUpdate.Success)
                    {
                        response.Success = basketUpdate.Success;
                        response.ErrorMessage = basketUpdate.ErrorMessage;
                        return await Task.FromResult(response);
                    }
                }
                else if (request.Quantity == -1)
                {
                    var culture = new CultureInfo("tr-TR");
                    double dbPrice = double.Parse(basket.Value.Price ?? "0.00", CultureInfo.InvariantCulture);
                    double reqPrice = double.Parse(request.Price ?? "0.00", CultureInfo.InvariantCulture);
                    double sumPrice = dbPrice - reqPrice;
                    string price = sumPrice.ToString("N", culture);
                    price = price.Replace(",", ".");
                    var basketUpdate = await _basketRepository.UpdateAsync(new Domain.Entity.Basket
                    {
                        MenuId = request.MenuId,
                        Quantity = basket.Value.Quantity - 1,
                        Price = price.ToString(),
                        UserId = UserSettings.UserId,
                    });
                    if (!basketUpdate.Success)
                    {
                        response.Success = basketUpdate.Success;
                        response.ErrorMessage = basketUpdate.ErrorMessage;
                        return await Task.FromResult(response);
                    }
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = "Quantity cannot be null";
                    return await Task.FromResult(response);
                }                
            }
            else
            {
                var addBasket = await _basketRepository.AddAsync(new Domain.Entity.Basket
                {
                    UserId = UserSettings.UserId,
                    RestaurantId = request.RestaurantId,
                    MenuId = request.MenuId,
                    Quantity = request.Quantity ?? 1,
                    Price = request.Price,
                    CurrencyCode = request.CurrencyCode ?? "CHF",
                    BasketDate = DateTime.UtcNow,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = 1,
                    IsActive = true,
                });

                if (!addBasket.Success)
                {
                    response.Success = addBasket.Success;
                    response.ErrorMessage = addBasket.ErrorMessage;
                    return await Task.FromResult(response);
                }

                response.Success = true;
                response.InfoMessage = "Başarılı";
            }

            response.Success = true;
            response.InfoMessage = "Operation finished successfully";
            return await Task.FromResult(response);
        }
    }
}
