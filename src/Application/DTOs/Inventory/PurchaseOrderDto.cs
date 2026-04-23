using Domain.Enums;

namespace Application.DTOs.Inventory;

public class PurchaseOrderDto
{
    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public DateTime? ExpectedDelivery { get; set; }
    public PurchaseOrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
    public string? ApprovedByName { get; set; }
    public List<PurchaseOrderItemDto> Items { get; set; } = new();
}