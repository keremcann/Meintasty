using MediatR;
using Meintasty.Application.Contract.Category.Queries;
using Meintasty.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meintasty.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public CategoryController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin,Member")]
        [HttpPost("getCategories")]
        public async Task<GeneralResponse<List<GetCategoryQueryResponse>>> GetCategories([FromBody] GetCategoryQueryRequest request)
        {
            GeneralResponse<List<GetCategoryQueryResponse>> response = await _mediator.Send(request);
            return response;
        }
    }
}
