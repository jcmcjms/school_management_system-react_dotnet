namespace Application.DTOs.Orders;

public class CartItemDto
{
    public Guid MenuItemId { get; set; }
    public int Quantity { get; set; }
}