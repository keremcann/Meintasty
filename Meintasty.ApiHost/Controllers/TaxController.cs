using MediatR;
using Meintasty.ApiHost.Helpers;
using Meintasty.Application.Contract.Tax.Commands;
using Meintasty.Application.Contract.Tax.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtTokenFilter("fvh8456477hth44j6wfds98bq9hp8bqh9ubq9gjig3qr0[94vj5")]
    public class TaxController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public TaxController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("getTaxById")]
        public async Task<GeneralResponse<GetTaxQueryResponse>> GetTaxById([FromBody] GetTaxQueryRequest request)
        {
            GeneralResponse<GetTaxQueryResponse> response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("addTax")]
        public async Task<GeneralResponse<CreateTaxCommandResponse>> AddTax([FromBody] CreateTaxCommandRequest request)
        {
            GeneralResponse<CreateTaxCommandResponse> response = await _mediator.Send(request);
            return response;
        }
    }
}
