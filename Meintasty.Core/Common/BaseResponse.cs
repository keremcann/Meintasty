using System.ComponentModel.DataAnnotations.Schema;

namespace Meintasty.Core.Common
{
    [Serializable]
    public abstract class BaseResponse
    {
        [NotMapped]
        public bool Success { get; set; }
        [NotMapped]
        public string? InfoMessage { get; set; }
        [NotMapped]
        public string? ErrorMessage { get; set; }
    }
}
