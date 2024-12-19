using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Canton.Queries;
using Meintasty.Application.Contract.Tax.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Tax
{
    public class GetTaxQueryHandler : IRequestHandler<GetTaxQueryRequest, GeneralResponse<List<GetTaxQueryResponse>>>
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
        public async Task<GeneralResponse<List<GetTaxQueryResponse>>> Handle(GetTaxQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetTaxQueryResponse>>();
            response.Value = new List<GetTaxQueryResponse>();

            if (request.TaxId == null || request.TaxId == 0) 
            {
                var taxes = await _taxRepository.GetAllAsync();
                if (!taxes.Success)
                {
                    response.Success = taxes.Success;
                    response.ErrorMessage = taxes.ErrorMessage;
                    return await Task.FromResult(response);
                }
                if (taxes.Value == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Not found Tax!";
                    return await Task.FromResult(response);
                }
                response.Value = _mapper.Map<List<GetTaxQueryResponse>>(taxes.Value);
                response.Success = true;
                response.InfoMessage = "Getting successfully";
            }
            else
            {
                var tax = await _taxRepository.GetAsync(new Domain.Entity.Tax { Id = Convert.ToInt32(request.TaxId) });
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
                var item = new GetTaxQueryResponse();
                item = _mapper.Map<GetTaxQueryResponse>(tax.Value);
                //response.Value = _mapper.Map<List<GetTaxQueryResponse>>(tax.Value);
                response.Value.Add(item);
                response.Success = true;
                response.InfoMessage = "Getting successfully";
            }

            return await Task.FromResult(response);
        }
    }
}
