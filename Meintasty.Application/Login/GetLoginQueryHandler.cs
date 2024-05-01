using MediatR;
using Meintasty.Application.Contract.Login.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Login
{
    /// <summary>
    /// 
    /// </summary>
    public class GetLoginQueryHandler : IRequestHandler<GetLoginQueryRequest, GeneralResponse<GetLoginQueryResponse>>
    {
        private readonly IUserRepositoryAsync _userRepository;

        public GetLoginQueryHandler(IUserRepositoryAsync userRepository) => _userRepository = userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<GetLoginQueryResponse>> Handle(GetLoginQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetLoginQueryResponse>();
            response.Value = new GetLoginQueryResponse();

            var user = _userRepository.GetAsync(new User 
            { 
                Email = request.Email, 
                Password = request.Password 
            });

            if (!user.Result.Success)
            {
                response.Success = user.Result.Success;
                response.ErrorMessage = user.Result.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (user.Result.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Kullanıcı bulunamadı!";
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Başarılı";
            response.Value.FullName = user.Result.Value.FullName;
            response.Value.Token = Guid.NewGuid().ToString();

            return await Task.FromResult(response);
        }
    }
}
