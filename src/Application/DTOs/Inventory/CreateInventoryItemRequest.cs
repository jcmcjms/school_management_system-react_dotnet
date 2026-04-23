namespace Application.DTOs.Inventory;

public class CreateInventoryItemRequest
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string UnitOfMeasure { get; set; } = string.Empty;
    public decimal CurrentStock { get; set; }
    public decimal MinStockLevel { get; set; }
    public decimal ReorderPoint { get; set; }
    public decimal CostPerUnit { get; set; }
    public Guid? SupplierId { get; set; }
}