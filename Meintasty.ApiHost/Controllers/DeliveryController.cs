using MediatR;
using Meintasty.ApiHost.Helpers;
using Meintasty.Application.Contract.Delivery.Commands;
using Meintasty.Application.Contract.Delivery.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtTokenFilter("fvh8456477hth44j6wfds98bq9hp8bqh9ubq9gjig3qr0[94vj5")]
    public class DeliveryController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public DeliveryController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("getDeliveryById")]
        public async Task<GeneralResponse<GetDeliveryQueryResponse>> GetDeliveryById([FromBody] GetDeliveryQueryRequest request)
        {
            GeneralResponse<GetDeliveryQueryResponse> response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("addDelivery")]
        public async Task<GeneralResponse<CreateDeliveryCommandResponse>> AddDelivery([FromBody] CreateDeliveryCommandRequest request)
        {
            GeneralResponse<CreateDeliveryCommandResponse> response = await _mediator.Send(request);
            return response;
        }
    }
}
