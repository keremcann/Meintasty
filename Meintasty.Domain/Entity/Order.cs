using Meintasty.Domain.Common;

namespace Meintasty.Domain.Entity
{
    [Serializable]
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public string? Name { get; set; }
        public string? OrderDate { get; set; }
        public string? Price { get; set; }
        public string? CurrencyCode { get; set; }
        public string? PaymentType { get; set; }
        public string? OrderTip { get; set; }
        public string? OrderStatus { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
