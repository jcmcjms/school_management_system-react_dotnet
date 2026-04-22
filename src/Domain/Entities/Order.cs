using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseEntity
{
    [MaxLength(50)]
    public string OrderNumber { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public OrderType OrderType { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal FinalAmount { get; set; }

    public TransactionSource PaymentMethod { get; set; }

    public DateTime OrderedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ScheduledFor { get; set; }

    public DateTime? ServedAt { get; set; }

    [MaxLength(500)]
    public string? QrToken { get; set; }

    public DateTime? QrExpiry { get; set; }

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}