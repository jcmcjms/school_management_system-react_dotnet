using Domain.Enums;

namespace Application.DTOs.Canteen;

public class CreateMenuScheduleRequest
{
    public DateOnly Date { get; set; }
    public Guid MenuItemId { get; set; }
    public MealType MealType { get; set; }
    public int AvailableQuantity { get; set; }
    public decimal? SpecialPrice { get; set; }
}