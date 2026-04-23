using Application.DTOs.Common;
using Application.DTOs.Wallet;

namespace Application.Interfaces;

public interface IWalletService
{
    Task<WalletDto> GetOrCreateAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Result<TransactionDto>> TopUpAsync(Guid walletId, TopUpRequest request, CancellationToken cancellationToken = default);
    Task<Result<TransactionDto>> DeductAsync(Guid walletId, decimal amount, Guid orderId, CancellationToken cancellationToken = default);
    Task<Result<TransactionDto>> RefundAsync(Guid walletId, decimal amount, Guid orderId, CancellationToken cancellationToken = default);
    Task<Result<bool>> SetLimitsAsync(Guid walletId, decimal? dailyLimit, decimal? monthlyLimit, CancellationToken cancellationToken = default);
    Task<PagedResult<TransactionDto>> GetTransactionHistoryAsync(Guid walletId, TransactionQueryRequest query, CancellationToken cancellationToken = default);
}