using Meintasty.Domain.Common;

namespace Meintasty.Domain.Entity
{
    [Serializable]
    public class Basket : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int MenuId { get; set; }
        public string? RestaurantName { get; set; }
        public string? MenuName { get; set; }
        public DateTime BasketDate { get; set; }
        public int Quantity { get; set; }
        public string? Price { get; set; }
        public string? CurrencyCode { get; set; }        
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
