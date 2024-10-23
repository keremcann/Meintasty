using MediatR;
using Meintasty.ApiHost.Helpers;
using Meintasty.Application.Contract.Login.Queries;
using Meintasty.Application.Contract.Register.Commands;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public RegisterController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<GeneralResponse<CreateUserCommandResponse>> SignUp([FromBody] CreateUserCommandRequest request)
        {
            GeneralResponse<CreateUserCommandResponse> response = await _mediator.Send(request);
            if (response.Success)
            {
                var loginRequest = new GetLoginQueryRequest
                {
                    UserId = response.Value.UserId,
                    Email = request.Email,
                    Password = request.Password,
                    FullName = response.Value.FullName
                };
                string token = MeinTastyHelper.GenerateToken(loginRequest, response.Value.RoleList);
                response.Value.Token = token;
            }
            return response;
        }
    }
}
