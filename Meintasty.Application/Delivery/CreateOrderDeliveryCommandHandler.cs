using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Delivery.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Delivery
{
    public class CreateOrderDeliveryCommandHandler : IRequestHandler<CreateOrderDeliveryCommandRequest, GeneralResponse<CreateOrderDeliveryCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IOrderDeliveryRepositoryAsync _orderDeliveryRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="orderDeliveryRepository"></param>
        public CreateOrderDeliveryCommandHandler(IMapper mapper, IOrderDeliveryRepositoryAsync orderDeliveryRepository)
        {
            _mapper = mapper;
            _orderDeliveryRepository = orderDeliveryRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<CreateOrderDeliveryCommandResponse>> Handle(CreateOrderDeliveryCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateOrderDeliveryCommandResponse>();
            response.Value = new CreateOrderDeliveryCommandResponse();

            var result = await _orderDeliveryRepository.AddAsync(new Domain.Entity.OrderDelivery
            {
                OrderId = request.OrderId,
                Status = request.Status,
                Description = request.Description,
            });
            if (!result.Success)
            {
                response.Success = false;
                response.ErrorMessage = result.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = result.InfoMessage;

            return await Task.FromResult(response);
        }
    }
}
