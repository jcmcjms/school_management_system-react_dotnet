using Domain.Enums;

namespace Application.DTOs.Wallet;

public class TopUpRequest
{
    public decimal Amount { get; set; }
    public TransactionSource Source { get; set; }
    public string? Description { get; set; }
}