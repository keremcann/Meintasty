using MediatR;
using Meintasty.Application.Contract.Login.Queries;
using Meintasty.Domain.Entity;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Login
{
    /// <summary>
    /// 
    /// </summary>
    public class GetLoginQueryHandler : IRequestHandler<GetLoginQueryRequest, GetLoginQueryResponse>
    {
        private readonly IUserRepositoryAsync _userRepository;

        public GetLoginQueryHandler(IUserRepositoryAsync userRepository) => _userRepository = userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetLoginQueryResponse> Handle(GetLoginQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GetLoginQueryResponse();

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
            response.FullName = user.Result.Value.FullName;
            response.Token = Guid.NewGuid().ToString();

            return await Task.FromResult(response);
        }
    }
}
