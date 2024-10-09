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
        private readonly IRoleRepositoryAsync _roleRepository;

        public GetLoginQueryHandler(IUserRepositoryAsync userRepository, IRoleRepositoryAsync roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

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

            var user = await _userRepository.GetAsync(new Domain.Entity.User
            { 
                Email = request.Email, 
                Password = request.Password 
            });

            if (!user.Success)
            {
                response.Success = user.Success;
                response.ErrorMessage = user.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (user.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Kullanıcı bulunamadı!";
                return await Task.FromResult(response);
            }

            var roles = await _roleRepository.GetAllByIdAsync(user.Value.Id);
            if (!roles.Success)
            {
                response.Success = roles.Success;
                response.ErrorMessage = roles.ErrorMessage;
                return await Task.FromResult(response);
            }
            if (roles.Value.Count > 0)
            {
                response.Value.RoleList = new List<string>();
                foreach (var role in roles.Value)
                    response.Value.RoleList.Add(role.RoleName ?? "Member");
            }

            response.Success = true;
            response.InfoMessage = "Başarılı";
            response.Value.FullName = user.Value.FullName;
            response.Value.UserId = user.Value.Id;

            return await Task.FromResult(response);
        }
    }
}
