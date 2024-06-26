using MediatR;
using Meintasty.Application.Contract.Basket.Commands;
using Meintasty.Application.Contract.User.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Basket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest, GeneralResponse<CreateBasketCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBasketRepositoryAsync _basketRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketRepository"></param>
        public CreateBasketCommandHandler(IBasketRepositoryAsync basketRepository)
        {
            _basketRepository = basketRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<CreateBasketCommandResponse>> Handle(CreateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateBasketCommandResponse>();
            response.Value = new CreateBasketCommandResponse();

            return await Task.FromResult(response);
        }
    }
}
