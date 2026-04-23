namespace Application.DTOs.Orders;

public class OrderDetailDto : OrderDto
{
    public int? TotalCalories { get; set; }
    public int? TotalProtein { get; set; }
    public int? TotalCarbs { get; set; }
    public int? TotalFats { get; set; }
    public int? TotalSodium { get; set; }
}