namespace Application.DTOs.Inventory;

public class WasteLogDto
{
    public Guid Id { get; set; }
    public Guid InventoryItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string LoggedByName { get; set; } = string.Empty;
    public DateTime LoggedAt { get; set; }
}