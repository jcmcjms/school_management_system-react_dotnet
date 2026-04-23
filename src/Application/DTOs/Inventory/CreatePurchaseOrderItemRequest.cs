namespace Application.DTOs.Inventory;

public class CreatePurchaseOrderItemRequest
{
    public Guid InventoryItemId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}