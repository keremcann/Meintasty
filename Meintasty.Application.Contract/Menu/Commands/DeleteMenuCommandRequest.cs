using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Menu.Commands
{
    [DataContract]
    public class DeleteMenuCommandRequest : IRequest<GeneralResponse<DeleteMenuCommandResponse>>
    {
        [DataMember]
        public int Id { get; set; }
    }
}
