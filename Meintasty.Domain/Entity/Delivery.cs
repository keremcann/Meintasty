﻿using Meintasty.Domain.Common;

namespace Meintasty.Domain.Entity
{
    [Serializable]
    public class Delivery : IEntity
    {
        public int Id { get; set; }
        public string? MinAmount { get; set; }
        public string? MaxAmount { get; set; }
        public string? MinDistance { get; set; }
        public string? MaxDistance { get; set; }
        public string? Currency { get; set; }
        public string? Description { get; set; }
        public bool? IsFree { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
