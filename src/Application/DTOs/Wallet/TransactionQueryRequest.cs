using Domain.Enums;

namespace Application.DTOs.Wallet;

public class TransactionQueryRequest : Common.PaginationParams
{
    public Guid? WalletId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<TransactionType>? Types { get; set; }
    public List<TransactionSource>? Sources { get; set; }
}