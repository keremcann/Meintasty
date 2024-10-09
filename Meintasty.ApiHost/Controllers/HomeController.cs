using MediatR;
using Meintasty.Application.Contract.Home.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public HomeController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("getFavoriteRestaurants")]
        public async Task<GeneralResponse<List<GetFavoriteRestaurantQueryResponse>>> GetFavoriteRestaurants([FromBody] GetFavoriteRestaurantQueryRequest request)
        {
            GeneralResponse<List<GetFavoriteRestaurantQueryResponse>> response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("getFavoriteMenus")]
        public async Task<GeneralResponse<List<GetFavoriteMenuQueryResponse>>> GetFavoriteMenus([FromBody] GetFavoriteMenuQueryRequest request)
        {
            GeneralResponse<List<GetFavoriteMenuQueryResponse>> response = await _mediator.Send(request);
            return response;
        }
    }
}
