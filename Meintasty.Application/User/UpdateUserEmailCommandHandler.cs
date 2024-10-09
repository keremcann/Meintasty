using MediatR;
using Meintasty.Application.Contract.User.Commands;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;
using System.Net;

namespace Meintasty.Application.User
{
    public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommandRequest, GeneralResponse<UpdateUserEmailCommandResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepositoryAsync _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public UpdateUserEmailCommandHandler(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<UpdateUserEmailCommandResponse>> Handle(UpdateUserEmailCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<UpdateUserEmailCommandResponse>();
            response.Value = new UpdateUserEmailCommandResponse();

            var result = await _userRepository.UpdateUserEmailAsync(new Domain.Entity.User
            {
                Id = request.UserId,
                Email = request.Email,
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
