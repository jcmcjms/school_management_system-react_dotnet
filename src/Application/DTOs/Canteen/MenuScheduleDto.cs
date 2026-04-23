using Domain.Enums;

namespace Application.DTOs.Canteen;

public class MenuScheduleDto
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public Guid MenuItemId { get; set; }
    public string MenuItemName { get; set; } = string.Empty;
    public MealType MealType { get; set; }
    public int AvailableQuantity { get; set; }
    public bool IsActive { get; set; }
    public decimal? SpecialPrice { get; set; }
}