using Domain.Enums;

namespace Application.DTOs.Wallet;

public class TransactionDto
{
    public Guid Id { get; set; }
    public Guid WalletId { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public TransactionSource Source { get; set; }
    public string ReferenceNumber { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal BalanceAfter { get; set; }
    public Guid? OrderId { get; set; }
    public DateTime CreatedAt { get; set; }
}