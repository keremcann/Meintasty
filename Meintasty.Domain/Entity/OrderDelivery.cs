using Meintasty.Domain.Common;

namespace Meintasty.Domain.Entity
{
    [Serializable]
    public class OrderDelivery : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
