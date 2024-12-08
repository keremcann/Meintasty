using MediatR;
using Meintasty.ApiHost.Helpers;
using Meintasty.Application.Contract.Login.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public LoginController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("generateToken")]
        public async Task<GeneralResponse<GetLoginQueryResponse>> GenerateToken([FromBody] GetLoginQueryRequest request)
        {
            GeneralResponse<GetLoginQueryResponse> response = await _mediator.Send(request);
            if (response.Success) 
            {
                request.UserId = response.Value.UserId;
                request.FullName = response.Value.FullName;
                string token =  MeinTastyHelper.GenerateToken(request, response.Value.RoleList);
                response.Value.Token = token;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("RestLogin")]
        public async Task<GeneralResponse<GetRestLoginQueryResponse>> RestLogin([FromBody] GetRestLoginQueryRequest request)
        {
            GeneralResponse<GetRestLoginQueryResponse> response = await _mediator.Send(request);
            if (response.Success)
            {
                request.FullName = response.Value.FullName;
                request.RestaurantId = response.Value.RestaurantId;
                request.Url = response.Value.Url;
                request.PhoneNumber = response.Value.PhoneNumber;
                string token = MeinTastyHelper.CreateToken(request, response.Value.RoleList);
                response.Value.Token = token;
            }
            return response;
        }
    }
}
