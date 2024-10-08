using Meintasty.Domain.Common;

namespace Meintasty.Domain.Entity
{
    [Serializable]
    public class UserAddress : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? AddressName { get; set; }
        public string? AddressText { get; set; }
        public string? Street { get; set; }
        public int CityCode { get; set; }
        public string? CityName { get; set; }
        public string? CantonName { get; set; }
        public string? ZipCode { get; set; }
        public bool IsDefault { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
