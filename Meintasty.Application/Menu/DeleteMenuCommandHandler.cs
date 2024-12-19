using AutoMapper;
using MediatR;
using Meintasty.Application.Contract.Menu.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;
using Meintasty.Domain.Shared.Globals;

namespace Meintasty.Application.Menu
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommandRequest, GeneralResponse<DeleteMenuCommandResponse>>
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
        public DeleteMenuCommandHandler(IMapper mapper, IRestaurantMenuRepositoryAsync restaurantMenuRepository)
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
        public async Task<GeneralResponse<DeleteMenuCommandResponse>> Handle(DeleteMenuCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<DeleteMenuCommandResponse>();
            response.Value = new DeleteMenuCommandResponse();

            var result = await _restaurantMenuRepository.DeleteAsync(new RestaurantMenu
            {
                Id = request.Id,
                DeleteUser = UserSettings.RestId,
                DeleteDate = DateTime.UtcNow,
            });

            if (!result.Success)
            {
                response.Success = result.Success;
                response.ErrorMessage = result.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Value = _mapper.Map<DeleteMenuCommandResponse>(result.Value);
            response.Success = true;
            response.InfoMessage = result.InfoMessage;

            return await Task.FromResult(response);
        }
    }
}
