using MediatR;
using Meintasty.ApiHost.Helpers;
using Meintasty.Application.Contract.Basket.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtTokenFilter("fvh8456477hth44j6wfds98bq9hp8bqh9ubq9gjig3qr0[94vj5")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public PaymentController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("payOrder")]
        public async Task<GeneralResponse<List<GetBasketQueryResponse>>> PayOrder([FromBody] GetBasketQueryRequest request)
        {
            GeneralResponse<List<GetBasketQueryResponse>> response = await _mediator.Send(request);
            return response;
        }
    }
}
