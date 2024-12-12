using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Tax.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Tax
{
    public class CreateTaxCommandHandler : IRequestHandler<CreateTaxCommandRequest, GeneralResponse<CreateTaxCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly ITaxRepositoryAsync _taxRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="taxRepository"></param>
        public CreateTaxCommandHandler(IMapper mapper, ITaxRepositoryAsync taxRepository)
        {
            _mapper = mapper;
            _taxRepository = taxRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<CreateTaxCommandResponse>> Handle(CreateTaxCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateTaxCommandResponse>();
            response.Value = new CreateTaxCommandResponse();

            return await Task.FromResult(response);
        }
    }
}
