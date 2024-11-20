using MediatR;
using Meintasty.Application.Contract.Restaurant.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public RestaurantController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin,Member")]
        [AllowAnonymous]
        [HttpPost("getRestaurantsByCityId")]
        public async Task<GeneralResponse<List<GetRestaurantsByCityIdQueryResponse>>> GetRestaurantsByCityId([FromBody] GetRestaurantsByCityIdQueryRequest request)
        {
            request.IsPaging = true;
            GeneralResponse<List<GetRestaurantsByCityIdQueryResponse>> response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("getRestaurantDetailById")]
        public async Task<GeneralResponse<GetRestaurantDetailByIdQueryResponse>> GetRestaurantDetailById([FromBody] GetRestaurantDetailByIdQueryRequest request)
        {
            GeneralResponse<GetRestaurantDetailByIdQueryResponse> response = await _mediator.Send(request);
            return response;
        }
    }
}
