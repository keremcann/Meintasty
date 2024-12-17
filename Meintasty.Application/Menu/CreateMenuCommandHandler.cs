using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Menu.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using Meintasty.Domain.Shared.Globals;

namespace Meintasty.Application.Menu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommandRequest, GeneralResponse<CreateMenuCommandResponse>>
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
        public CreateMenuCommandHandler(IMapper mapper, IRestaurantMenuRepositoryAsync restaurantMenuRepository)
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
        public async Task<GeneralResponse<CreateMenuCommandResponse>> Handle(CreateMenuCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateMenuCommandResponse>();
            response.Value = new CreateMenuCommandResponse();

            var result = await _restaurantMenuRepository.AddAsync(new RestaurantMenu
            {
                RestaurantId = UserSettings.RestId,
                CategoryId = request.CategoryId,
                MenuName = request.MenuName,
                MenuPic = request.MenuPic,
                MenuContent = request.MenuContent,
                MenuPrice = request.MenuPrice,
                Currency = request.Currency ?? "CHF",
                CreateUser = 1,
                CreateDate = DateTime.UtcNow,
                IsActive = true,
            });

            if (!result.Success)
            {
                response.Success = result.Success;
                response.ErrorMessage = result.ErrorMessage;
                return await Task.FromResult(response);
            }

            //response.Value = _mapper.Map<CreateMenuCommandResponse>(result.Value);
            response.Success = true;
            response.InfoMessage = result.InfoMessage;

            return await Task.FromResult(response);
        }
    }
}
