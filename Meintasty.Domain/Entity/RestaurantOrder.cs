using Meintasty.Domain.Common;
using System.Runtime.Serialization;

namespace Meintasty.Domain.Entity
{
    [Serializable]
    public class RestaurantOrder : IEntity
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? OrderPrice { get; set; }
        public string? Currency { get; set; }
        public string? PaymentType { get; set; }
        public string? OrderTip { get; set; }
        public bool? IsPaid { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
