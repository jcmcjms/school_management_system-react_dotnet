using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Transaction : BaseEntity
{
    public Guid WalletId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    public TransactionType Type { get; set; }

    public TransactionSource Source { get; set; }

    [MaxLength(100)]
    public string ReferenceNumber { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal BalanceAfter { get; set; }

    public Guid? OrderId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(WalletId))]
    public virtual Wallet Wallet { get; set; } = null!;

    [ForeignKey(nameof(OrderId))]
    public virtual Order? Order { get; set; }
}