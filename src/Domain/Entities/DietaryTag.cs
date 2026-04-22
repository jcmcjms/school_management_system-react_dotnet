using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class DietaryTag: BaseEntity
{
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public DietaryTagType Type { get; set; }
    [MaxLength(50)]
    public string Icon { get; set; } = string.Empty;
    // Navigation properties
    public virtual ICollection<MenuItemDietaryTag> MenuItems { get; set; } = new List<MenuItemDietaryTag>();
}