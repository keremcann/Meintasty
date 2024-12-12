using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Delivery.Queries;
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

            return await Task.FromResult(response);
        }
    }
}
