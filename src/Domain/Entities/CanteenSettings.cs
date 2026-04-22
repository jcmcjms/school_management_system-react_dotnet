using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class CanteenSettings : BaseEntity
{
    public TimeOnly OpeningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }

    public TimeOnly PreOrderDeadline { get; set; }

    public int MaxDailyOrderLimit { get; set; }

    public bool AllowWalkInOrders { get; set; } = true;

    [Column(TypeName = "decimal(18,2)")]
    public decimal StaffDiscountPercent { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal StudentDiscountPercent { get; set; }
}