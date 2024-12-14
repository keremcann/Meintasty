using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Delivery.Queries;
using Meintasty.Application.Contract.Tax.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Delivery
{
    public class GetDeliveryQueryHandler : IRequestHandler<GetDeliveryQueryRequest, GeneralResponse<GetDeliveryQueryResponse>>
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
        public async Task<GeneralResponse<GetDeliveryQueryResponse>> Handle(GetDeliveryQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetDeliveryQueryResponse>();
            response.Value = new GetDeliveryQueryResponse();

            var delivery = await _deliveryRepository.GetAsync(new Domain.Entity.Delivery { Id = request.DeliveryId });
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

            response.Value = _mapper.Map<GetDeliveryQueryResponse>(delivery.Value);
            response.Success = true;
            response.InfoMessage = "Getting successfully";

            return await Task.FromResult(response);
        }
    }
}
