using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class MenuItem: BaseEntity
{
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string? Description { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal CostPrice { get; set; }
    public MenuCategory Category { get; set; }

    [MaxLength(500)]
    public string? ImageUrl { get; set; }
    public int PreparationTime { get; set; }
    public bool IsAvailable { get; set; } = true;
    public int? Calories { get; set; }
    public int? Protein { get; set; }
    public int? Carbs { get; set; }
    public int? Fats { get; set; }
    public int? Sodium { get; set; }
    // Navigation properties
    public virtual ICollection<MenuItemDietaryTag> DietaryTags { get; set; } = new List<MenuItemDietaryTag>();
    public virtual ICollection<MenuSchedule> MenuSchedules { get; set; } = new List<MenuSchedule>();
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}