using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Menu.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Menu
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommandRequest, GeneralResponse<UpdateMenuCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IRestaurantMenuRepositoryAsync _restaurantMenuRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="restaurantMenuRepository"></param>
        public UpdateMenuCommandHandler(IMapper mapper, IRestaurantMenuRepositoryAsync restaurantMenuRepository)
        {
            _mapper = mapper;
            _restaurantMenuRepository = restaurantMenuRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<UpdateMenuCommandResponse>> Handle(UpdateMenuCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<UpdateMenuCommandResponse>();
            response.Value = new UpdateMenuCommandResponse();

            var result = await _restaurantMenuRepository.UpdateAsync(new RestaurantMenu
            {
                Id = request.Id,
                RestaurantId = request.RestaurantId,
                CategoryId = request.CategoryId,
                MenuName = request.MenuName,
                MenuPic = request.MenuPic,
                MenuContent = request.MenuContent,
                MenuPrice = request.MenuPrice,
                Currency = request.Currency,
                UpdateUser = 1,
                UpdateDate = DateTime.UtcNow,
            });

            if (!result.Success)
            {
                response.Success = result.Success;
                response.ErrorMessage = result.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Value = _mapper.Map<UpdateMenuCommandResponse>(result.Value);

            return await Task.FromResult(response);
        }
    }
}
