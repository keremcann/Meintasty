namespace Meintasty.Domain.Common
{
    public interface IEntity
    {
        int Id { get; set; }
        int CreateUser { get; set; }
        DateTime CreateDate { get; set; }
        int? UpdateUser { get; set; }
        DateTime? UpdateDate { get; set; }
        int? DeleteUser { get; set; }
        DateTime? DeleteDate { get; set; }
        bool IsActive { get; set; }
    }
}
