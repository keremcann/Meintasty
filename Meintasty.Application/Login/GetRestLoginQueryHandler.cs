using MediatR;
using Meintasty.Application.Contract.Login.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Login
{
    public class GetRestLoginQueryHandler : IRequestHandler<GetRestLoginQueryRequest, GeneralResponse<GetRestLoginQueryResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IRestaurantRepositoryAsync _resraurantRepositoy;
        public GetRestLoginQueryHandler(IRestaurantRepositoryAsync resraurantRepositoy)
        {
            _resraurantRepositoy = resraurantRepositoy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<GeneralResponse<GetRestLoginQueryResponse>> Handle(GetRestLoginQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetRestLoginQueryResponse>();
            response.Value = new GetRestLoginQueryResponse();

            var rest = await _resraurantRepositoy.GetRestaurantByInfoAsync(request?.Email, request.Password);

            if (!rest.Success)
            {
                response.Success = rest.Success;
                response.ErrorMessage = rest.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (rest.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Restaurant bulunamadı!";
                return await Task.FromResult(response);
            }
            response.Value.FullName = rest.Value.RestaurantName;
            response.Value.RestaurantId = rest.Value.Id;
            response.Value.Url = rest.Value.Url;
            response.Value.PhoneNumber = rest.Value.PhoneNumber;
            response.Value.RoleList = new List<string>();
            response.Value.RoleList.Add("Restaurant");
            response.Success = rest.Success;
            response.InfoMessage = rest.InfoMessage;

            return await Task.FromResult(response);
        }
    }
}
