using MediatR;
using Meintasty.Application.Contract.User.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, GeneralResponse<UpdateUserCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepositoryAsync _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public UpdateUserCommandHandler(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<UpdateUserCommandResponse>();
            response.Value = new UpdateUserCommandResponse();

            var result = await _userRepository.UpdateAsync(new Domain.Entity.User
            {
                Id = request.UserId,
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                BirthDate = request.BirthDate,
                Password = request.Password,
                IsEmailVerified = request.IsEmailVerified,
                IsPhoneVerified = request.IsPhoneVerified,
                ProfilePicture = request.ProfilePicture,
                UpdateUser = 1,
                UpdateDate = DateTime.UtcNow
            });

            if (!result.Success)
            {
                response.Success = result.Success;
                response.ErrorMessage = result.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Process finised successfully!";

            return await Task.FromResult(response);
        }
    }
}
