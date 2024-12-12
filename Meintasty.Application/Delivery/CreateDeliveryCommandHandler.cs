using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Delivery.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Delivery
{
    public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommandRequest, GeneralResponse<CreateDeliveryCommandResponse>>
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
        public CreateDeliveryCommandHandler(IMapper mapper, IDeliveryRepositoryAsync deliveryRepository)
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
        public async Task<GeneralResponse<CreateDeliveryCommandResponse>> Handle(CreateDeliveryCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateDeliveryCommandResponse>();
            response.Value = new CreateDeliveryCommandResponse();

            return await Task.FromResult(response);
        }
    }
}
