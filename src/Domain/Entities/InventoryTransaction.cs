using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class InventoryTransaction : BaseEntity
{
    public Guid InventoryItemId { get; set; }

    public InventoryTransactionType Type { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Quantity { get; set; }

    [MaxLength(500)]
    public string Reason { get; set; } = string.Empty;

    public Guid? ReferenceOrderId { get; set; }

    public Guid? ReferencePurchaseOrderId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(InventoryItemId))]
    public virtual InventoryItem InventoryItem { get; set; } = null!;
}