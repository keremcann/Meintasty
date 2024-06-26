using MediatR;
using Meintasty.Application.Contract.User.Commands;
using Meintasty.Application.Contract.User.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public UserController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("getUser")]
        public async Task<IActionResult> GetUser([FromBody] GetUserQueryRequest request)
        {
            GeneralResponse<GetUserQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest request)
        {
            GeneralResponse<UpdateUserCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("removeUser")]
        public async Task<IActionResult> RemoveUser([FromBody] DeleteUserCommandRequest request)
        {
            GeneralResponse<DeleteUserCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
