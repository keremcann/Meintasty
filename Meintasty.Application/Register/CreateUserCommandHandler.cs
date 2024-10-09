using MediatR;
using Meintasty.Application.Contract.Register.Commands;
using Meintasty.Core.Common;
using Meintasty.Core.Helpers;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.Register
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, GeneralResponse<CreateUserCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IUserRoleRepositoryAsync _userRoleRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="userRoleRepository"></param>
        public CreateUserCommandHandler(IUserRepositoryAsync userRepository, IUserRoleRepositoryAsync userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateUserCommandResponse>();
            response.Value = new CreateUserCommandResponse();

            if (string.IsNullOrEmpty(request.FullName) || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                response.Success = false;
                response.ErrorMessage = "Please check input for not null!";
                return await Task.FromResult(response);
            }

            if (!request.Email.ChechEmail())
            {
                response.Success = false;
                response.ErrorMessage = "Please check email format!";
                return await Task.FromResult(response);
            }
            /*
            if (!request.Password.Equals(request.RePassword))
            {
                response.Success = false;
                response.ErrorMessage = "Password does not match!";
                return await Task.FromResult(response);
            }
            */
            var user = await _userRepository.AddAsync(new Domain.Entity.User
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password,
                CreateUser = 1,
                CreateDate = DateTime.UtcNow,
                IsActive = true,
            });

            if (!user.Success)
            {
                response.Success = user.Success;
                response.ErrorMessage = user.ErrorMessage;
                return await Task.FromResult(response);
            }

            var userRole = await _userRoleRepository.AddAsync(new Domain.Entity.UserRole
            {
                UserId = user.Value.Id,
                RoleId = 2,
                CreateUser = 1,
                CreateDate = DateTime.UtcNow,
                IsActive = true
            });

            if (!userRole.Success)
            {
                response.Success = userRole.Success;
                response.ErrorMessage = userRole.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Başarılı";
            response.Value.FullName = user?.Value?.FullName ?? string.Empty;

            return await Task.FromResult(response);
        }
    }
}
