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
        public async Task<GeneralResponse<List<GetBasketQueryResponse>>> GetBaskets([FromBody] GetBasketQueryRequest request)
        {
            GeneralResponse<List<GetBasketQueryResponse>> response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("addBasket")]
        public async Task<GeneralResponse<CreateBasketCommandResponse>> AddBasket([FromBody] CreateBasketCommandRequest request)
        {
            GeneralResponse<CreateBasketCommandResponse> response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("updateBasket")]
        public async Task<GeneralResponse<UpdateBasketCommandResponse>> UpdateBasket([FromBody] UpdateBasketCommandRequest request)
        {
            GeneralResponse<UpdateBasketCommandResponse> response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("removeBasket")]
        public async Task<GeneralResponse<DeleteBasketCommandResponse>> RemoveBasket([FromBody] DeleteBasketCommandRequest request)
        {
            GeneralResponse<DeleteBasketCommandResponse> response = await _mediator.Send(request);
            return response;
        }
    }
}
