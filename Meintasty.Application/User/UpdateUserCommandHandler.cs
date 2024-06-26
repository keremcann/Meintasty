using MediatR;
using Meintasty.Application.Contract.Register.Commands;
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

            return await Task.FromResult(response);
        }
    }
}
