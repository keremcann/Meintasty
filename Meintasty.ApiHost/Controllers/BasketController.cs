using MediatR;
using Meintasty.Application.Contract.Basket.Commands;
using Meintasty.Application.Contract.Basket.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public BasketController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("getBaskets")]
        public async Task<IActionResult> GetBaskets([FromBody] GetBasketQueryRequest request)
        {
            GeneralResponse<List<GetBasketQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("addBasket")]
        public async Task<IActionResult> AddBasket([FromBody] CreateBasketCommandRequest request)
        {
            GeneralResponse<CreateBasketCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("updateBasket")]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasketCommandRequest request)
        {
            GeneralResponse<UpdateBasketCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("removeBasket")]
        public async Task<IActionResult> RemoveBasket([FromBody] DeleteBasketCommandRequest request)
        {
            GeneralResponse<DeleteBasketCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
