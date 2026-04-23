using Domain.Enums;

namespace Application.DTOs.Orders;

public class OrderDto
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public OrderType OrderType { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public TransactionSource PaymentMethod { get; set; }
    public DateTime OrderedAt { get; set; }
    public DateTime? ScheduledFor { get; set; }
    public DateTime? ServedAt { get; set; }
    public string? QrToken { get; set; }
    public DateTime? QrExpiry { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}