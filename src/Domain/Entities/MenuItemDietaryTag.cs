using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class MenuItemDietaryTag
{
    public Guid MenuItemId { get; set; }
    public Guid DietaryTagId { get; set; }
    // Navigation properties
    [ForeignKey(nameof(MenuItemId))]
    public virtual MenuItem MenuItem { get; set; } = null!;
    [ForeignKey(nameof(DietaryTagId))]
    public virtual DietaryTag DietaryTag { get; set; } = null!;
}