﻿using MediatR;
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
                string token =  MeinTastyHelper.GenerateToken(request, response.Value.RoleList);
                response.Value.Token = token;
            }
            return response;
        }
    }
}
