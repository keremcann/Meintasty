using Meintasty.Domain.Common;

namespace Meintasty.Domain.Entity
{
    [Serializable]
    public class RestaurantMenu : IEntity
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public string? MenuPrice { get; set; }
        public string? Currency { get; set; }
        public byte[]? MenuPic { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
