using Domain.Enums;

namespace Application.DTOs.Orders;

public class PlaceOrderRequest
{
    public List<CartItemDto> Items { get; set; } = new();
    public OrderType OrderType { get; set; }
    public DateTime? ScheduledFor { get; set; }
    public TransactionSource PaymentMethod { get; set; }
}