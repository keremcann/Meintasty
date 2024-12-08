using MediatR;
using Meintasty.Core.Common;
using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Menu.Commands
{
    [DataContract]
    public class CreateMenuCommandRequest : IRequest<GeneralResponse<CreateMenuCommandResponse>>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RestaurantId { get; set; }
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public string? MenuName { get; set; }
        [DataMember]
        public byte[]? MenuPic { get; set; }
        [DataMember]
        public string? MenuContent { get; set; }
        [DataMember]
        public string? MenuPrice { get; set; }
        [DataMember]
        public string? Currency { get; set; }
    }
}
