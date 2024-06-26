﻿using MediatR;
using Meintasty.Application.Contract.Order.Commands;
using Meintasty.Application.Contract.Order.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public OrderController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("getOrders")]
        public async Task<IActionResult> GetOrders([FromBody] GetOrderQueryRequest request)
        {
            GeneralResponse<List<GetOrderQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("addOrder")]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderCommandRequest request)
        {
            GeneralResponse<CreateOrderCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("updateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommandRequest request)
        {
            GeneralResponse<UpdateOrderCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("removeOrder")]
        public async Task<IActionResult> RemoveOrder([FromBody] DeleteOrderCommandRequest request)
        {
            GeneralResponse<DeleteOrderCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}