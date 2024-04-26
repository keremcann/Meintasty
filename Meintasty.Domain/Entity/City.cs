using Meintasty.Domain.Common;

namespace Meintasty.Domain.Entity
{
    [Serializable]
    public class City : IEntity
    {
        public int Id { get; set; }
        public int CantonId { get; set; }
        public string? CityName { get; set; }
        public int CityCode { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
