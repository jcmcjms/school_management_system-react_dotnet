using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class IngredientRequest : BaseEntity
{
    public Guid InventoryItemId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal QuantityNeeded { get; set; }

    [MaxLength(20)]
    public string Urgency { get; set; } = "Medium"; // Low, Medium, High

    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

    public Guid RequestedBy { get; set; }

    public Guid? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    // Navigation properties
    [ForeignKey(nameof(InventoryItemId))]
    public virtual InventoryItem InventoryItem { get; set; } = null!;
}