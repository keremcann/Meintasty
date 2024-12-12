using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Tax.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Tax
{
    public class GetTaxQueryHandler : IRequestHandler<GetTaxQueryRequest, GeneralResponse<GetTaxQueryResponse>>
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
        public GetTaxQueryHandler(IMapper mapper, ITaxRepositoryAsync taxRepository)
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
        public async Task<GeneralResponse<GetTaxQueryResponse>> Handle(GetTaxQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetTaxQueryResponse>();
            response.Value = new GetTaxQueryResponse();

            return await Task.FromResult(response);
        }
    }
}
