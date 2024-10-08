using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Canton.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Canton
{
    public class GetCantonQueryHandler : IRequestHandler<GetCantonQueryRequest, GeneralResponse<List<GetCantonQueryResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly ICantonRepositoryAsync _cantonRepository;
        private readonly ICityRepositoryAsync _cityRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cantonRepository"></param>
        /// <param name="cityRepository"></param>
        public GetCantonQueryHandler(IMapper mapper, ICantonRepositoryAsync cantonRepository, ICityRepositoryAsync cityRepository)
        {
            _mapper = mapper;
            _cantonRepository = cantonRepository;
            _cityRepository = cityRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<List<GetCantonQueryResponse>>> Handle(GetCantonQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetCantonQueryResponse>>();
            response.Value = new List<GetCantonQueryResponse>();

            var cantons = _cantonRepository.GetAllAsync();
            
            if (!cantons.Result.Success)
            {
                response.Success = cantons.Result.Success;
                response.ErrorMessage = cantons.Result.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (cantons.Result.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found any Canton!";
                return await Task.FromResult(response);
            }

            var cities = _cityRepository.GetAllAsync();
            if (!cities.Result.Success)
            {
                response.Success = cities.Result.Success;
                response.ErrorMessage = cities.Result.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (cities.Result.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found any City!";
                return await Task.FromResult(response);
            }

            foreach (var canton in cantons.Result.Value)
            {
                var cityList = cities.Result.Value.Where(x => x.CantonId == canton.Id).ToList();
                canton.Cities = new List<Domain.Entity.City>();
                canton.Cities.AddRange(cityList);
            }

            response.Value = _mapper.Map<List<GetCantonQueryResponse>>(cantons.Result.Value);
            response.Success = true;
            response.InfoMessage = "Success";

            return await Task.FromResult(response);
        }
    }
}
