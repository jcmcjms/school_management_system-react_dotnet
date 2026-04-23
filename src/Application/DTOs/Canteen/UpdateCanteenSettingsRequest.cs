namespace Application.DTOs.Canteen;

public class UpdateCanteenSettingsRequest
{
    public TimeOnly OpeningTime { get; set; }
    public TimeOnly ClosingTime { get; set; }
    public TimeOnly PreOrderDeadline { get; set; }
    public int MaxDailyOrderLimit { get; set; }
    public bool AllowWalkInOrders { get; set; }
    public decimal StaffDiscountPercent { get; set; }
    public decimal StudentDiscountPercent { get; set; }
}