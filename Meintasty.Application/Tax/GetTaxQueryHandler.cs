using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Canton.Queries;
using Meintasty.Application.Contract.Tax.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Entity;
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

            var tax = await _taxRepository.GetAsync(new Domain.Entity.Tax { Id = request.TaxId });
            if (!tax.Success)
            {
                response.Success = tax.Success;
                response.ErrorMessage = tax.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (tax.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found Tax!";
                return await Task.FromResult(response);
            }

            response.Value = _mapper.Map<GetTaxQueryResponse>(tax.Value);
            response.Success = true;
            response.InfoMessage = "Getting successfully";

            return await Task.FromResult(response);
        }
    }
}
