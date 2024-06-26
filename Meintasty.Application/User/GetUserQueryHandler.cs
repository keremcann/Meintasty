using MediatR;
using Meintasty.Application.Contract.User.Queries;
using Meintasty.Core.Common;
using Meintasty.Domain.Repository;

namespace Meintasty.Application.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GeneralResponse<GetUserQueryResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepositoryAsync _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public GetUserQueryHandler(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GeneralResponse<GetUserQueryResponse>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetUserQueryResponse>();
            response.Value = new GetUserQueryResponse();

            return await Task.FromResult(response);
        }
    }
}
