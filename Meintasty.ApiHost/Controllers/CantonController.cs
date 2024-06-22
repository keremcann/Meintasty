using MediatR;
using Meintasty.Application.Contract.Canton.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantonController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public CantonController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin,Member")]
        [AllowAnonymous]
        [HttpPost("getCantonsAndCities")]
        public async Task<IActionResult> GetCantonsAndCities([FromBody] GetCantonQueryRequest request)
        {
            GeneralResponse<List<GetCantonQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
