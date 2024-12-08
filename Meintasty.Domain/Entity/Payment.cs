using Meintasty.Domain.Common;

namespace Meintasty.Domain.Entity
{
    [Serializable]
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int TransactionId { get; set; }
        public string? Description { get; set; }
        public string? Amount { get; set; }
        public string? Currency { get; set; }
        public string? PaymentType { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
