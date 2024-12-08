using MediatR;
using Meintasty.ApiHost.Helpers;
using Meintasty.Application.Contract.Menu.Commands;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtTokenFilter("fvh8456477hth44j6wfds98bq9hp8bqh9ubq9gjig3qr0[94vj5")]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public MenuController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Restaurant")]
        [HttpPost("createMenu")]
        public async Task<GeneralResponse<CreateMenuCommandResponse>> CreateMenu([FromBody] CreateMenuCommandRequest request)
        {
            GeneralResponse<CreateMenuCommandResponse> response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Restaurant")]
        [HttpPost("updateMenu")]
        public async Task<GeneralResponse<UpdateMenuCommandResponse>> UpdateMenu([FromBody] UpdateMenuCommandRequest request)
        {
            GeneralResponse<UpdateMenuCommandResponse> response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Restaurant")]
        [HttpPost("removeMenu")]
        public async Task<GeneralResponse<DeleteMenuCommandResponse>> RemoveMenu([FromBody] DeleteMenuCommandRequest request)
        {
            GeneralResponse<DeleteMenuCommandResponse> response = await _mediator.Send(request);
            return response;
        }
    }
}
