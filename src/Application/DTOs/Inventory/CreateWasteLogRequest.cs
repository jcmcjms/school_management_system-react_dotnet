namespace Application.DTOs.Inventory;

public class CreateWasteLogRequest
{
    public Guid InventoryItemId { get; set; }
    public decimal Quantity { get; set; }
    public string Reason { get; set; } = string.Empty;
}