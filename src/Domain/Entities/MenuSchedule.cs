using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class MenuSchedule : BaseEntity
{
    public DateOnly Date { get; set; }

    public Guid MenuItemId { get; set; }

    public MealType MealType { get; set; }

    public int AvailableQuantity { get; set; }

    public bool IsActive { get; set; } = true;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? SpecialPrice { get; set; }

    // Navigation properties
    [ForeignKey(nameof(MenuItemId))]
    public virtual MenuItem MenuItem { get; set; } = null!;
}