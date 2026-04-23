namespace Application.DTOs.Inventory;

public class CreatePurchaseOrderRequest
{
    public Guid SupplierId { get; set; }
    public DateTime? ExpectedDelivery { get; set; }
    public List<CreatePurchaseOrderItemRequest> Items { get; set; } = new();
}