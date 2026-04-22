using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class InventoryItem : BaseEntity
{
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    [MaxLength(50)]
    public string UnitOfMeasure { get; set; } = string.Empty; // e.g., kg, liter, piece

    [Column(TypeName = "decimal(18,2)")]
    public decimal CurrentStock { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal MinStockLevel { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal ReorderPoint { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal CostPerUnit { get; set; }

    public Guid? SupplierId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(SupplierId))]
    public virtual Supplier? Supplier { get; set; }

    public virtual ICollection<InventoryTransaction> Transactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<WasteLog> WasteLogs { get; set; } = new List<WasteLog>();

    public virtual ICollection<IngredientRequest> IngredientRequests { get; set; } = new List<IngredientRequest>();

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
}