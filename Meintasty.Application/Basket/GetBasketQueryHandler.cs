﻿using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Basket.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;
using Meintasty.Domain.Shared.Globals;

namespace Meintasty.Application.Basket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQueryRequest, GeneralResponse<List<GetBasketQueryResponse>>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IBasketRepositoryAsync _basketRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketRepository"></param>
        public GetBasketQueryHandler(IMapper mapper, IBasketRepositoryAsync basketRepository)
        {
            _mapper = mapper;
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

            var baskets = await _basketRepository.GetAllByInfoAsync(new Domain.Entity.Basket
            {
                UserId = UserSettings.UserId,//request.UserId,
                RestaurantId = request.RestaurantId,
            });

            if (!baskets.Success)
            {
                response.Success = baskets.Success;
                response.ErrorMessage = baskets.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (baskets.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Sepet boş!";
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Başarılı";
            response.Value = _mapper.Map<List<GetBasketQueryResponse>>(baskets.Value);

            var list = new List<GetBasketQueryResponse>();
            var basketList = response.Value.GroupBy(x => x.MenuId).ToList();
            foreach (var item in basketList)
            {
                var basketItem = new GetBasketQueryResponse();
                basketItem = item.FirstOrDefault();
                basketItem.Quantity = item.Count();
                //basketItem.Price = (Convert.ToDouble(basketItem.Price) * basketItem.Quantity).ToString();
                list.Add(basketItem);
            }

            response.Value = new List<GetBasketQueryResponse>();
            response.Value = list;

            return await Task.FromResult(response);
        }
    }
}
