using Meintasty.Domain.Common;

namespace Meintasty.Domain.Entity
{
    [Serializable]
    public class Restaurant : IEntity
    {
        public int Id { get; set; }
        public string? RestaurantName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? TaxNumber { get; set; }
        public string? WorkDayFrom { get; set; }
        public string? WorkDayTo { get; set; }
        public string? WorkHourFrom { get; set; }
        public string? WorkHourTo { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
