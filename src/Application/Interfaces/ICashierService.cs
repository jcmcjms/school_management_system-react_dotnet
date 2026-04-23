using Application.DTOs.Cashier;
using Application.DTOs.Common;
using Application.DTOs.Orders;
using Application.DTOs.Wallet;

namespace Application.Interfaces;

public interface ICashierService
{
    Task<Result<OrderDto>> CreateWalkInOrderAsync(PlaceOrderRequest request, Guid cashierId, CancellationToken cancellationToken = default);
    Task<Result<bool>> ProcessCashPaymentAsync(Guid orderId, decimal amountReceived, Guid cashierId, CancellationToken cancellationToken = default);
    Task<Result<OrderDto>> VerifyAndServeAsync(string qrToken, Guid cashierId, CancellationToken cancellationToken = default);
    Task<Result<TransactionDto>> TopUpWalletAtCounterAsync(Guid userId, decimal amount, Guid cashierId, CancellationToken cancellationToken = default);
    Task<DailySummaryDto> GetDailySummaryAsync(DateTime date, CancellationToken cancellationToken = default);
}