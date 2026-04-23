namespace Application.DTOs.Inventory;

public class InventoryItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string UnitOfMeasure { get; set; } = string.Empty;
    public decimal CurrentStock { get; set; }
    public decimal MinStockLevel { get; set; }
    public decimal ReorderPoint { get; set; }
    public decimal CostPerUnit { get; set; }
    public string? SupplierName { get; set; }
    public bool IsLowStock => CurrentStock <= MinStockLevel;
}