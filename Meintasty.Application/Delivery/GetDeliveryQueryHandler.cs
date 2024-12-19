using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Delivery.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Delivery
{
    public class GetDeliveryQueryHandler : IRequestHandler<GetDeliveryQueryRequest, GeneralResponse<List<GetDeliveryQueryResponse>>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IDeliveryRepositoryAsync _deliveryRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="deliveryRepository"></param>
        public GetDeliveryQueryHandler(IMapper mapper, IDeliveryRepositoryAsync deliveryRepository)
        {
            _mapper = mapper;
            _deliveryRepository = deliveryRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<GetDeliveryQueryResponse>>> Handle(GetDeliveryQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetDeliveryQueryResponse>>();
            response.Value = new List<GetDeliveryQueryResponse>();

            if (request.DeliveryId != null && request.DeliveryId > 0)
            {
                var delivery = await _deliveryRepository.GetAsync(new Domain.Entity.Delivery { Id = (int)request.DeliveryId });
                if (!delivery.Success)
                {
                    response.Success = delivery.Success;
                    response.ErrorMessage = delivery.ErrorMessage;
                    return await Task.FromResult(response);
                }
                if (delivery.Value == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Not found delivery!";
                    return await Task.FromResult(response);
                }

                GetDeliveryQueryResponse item = new GetDeliveryQueryResponse();
                item = _mapper.Map<GetDeliveryQueryResponse>(delivery.Value);
                response.Value.Add(item);
                response.Success = true;
                response.InfoMessage = delivery.InfoMessage;
            }
            else 
            {
                var deliveries = await _deliveryRepository.GetAllAsync();
                if (!deliveries.Success)
                {
                    response.Success = deliveries.Success;
                    response.ErrorMessage = deliveries.ErrorMessage;
                    return await Task.FromResult(response);
                }
                if (deliveries.Value == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Not found delivery!";
                    return await Task.FromResult(response);
                }
                response.Value = _mapper.Map<List<GetDeliveryQueryResponse>>(deliveries.Value);
                response.Success = true;
                response.InfoMessage = deliveries.InfoMessage;
            }

            return await Task.FromResult(response);
        }
    }
}
