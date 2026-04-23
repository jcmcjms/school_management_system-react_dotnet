using Domain.Enums;

namespace Application.DTOs.Canteen;

public class MenuItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal CostPrice { get; set; }
    public MenuCategory Category { get; set; }
    public string? ImageUrl { get; set; }
    public int PreparationTime { get; set; }
    public bool IsAvailable { get; set; }
    public int? Calories { get; set; }
    public int? Protein { get; set; }
    public int? Carbs { get; set; }
    public int? Fats { get; set; }
    public int? Sodium { get; set; }
    public List<DietaryTagDto> DietaryTags { get; set; } = new();
}