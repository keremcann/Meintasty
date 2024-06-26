using MediatR;
using Meintasty.Application.Contract.Register.Commands;
using Meintasty.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Meintasty.Application.Contract.User.Commands
{
    [DataContract]
    public class DeleteUserCommandRequest : IRequest<GeneralResponse<DeleteUserCommandResponse>>
    {
    }
}
