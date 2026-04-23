using Application.DTOs.Common;
using Application.DTOs.Orders;

namespace Application.Interfaces;

public interface IKitchenService
{
    Task<PagedResult<OrderDto>> GetTodayOrdersAsync(PaginationParams parameters, CancellationToken cancellationToken = default);
    Task<Result<bool>> StartPreparingAsync(Guid orderId, Guid cookId, CancellationToken cancellationToken = default);
    Task<Result<bool>> MarkReadyAsync(Guid orderId, Guid cookId, CancellationToken cancellationToken = default);
    Task<Result<bool>> LogIngredientUsageAsync(Guid inventoryItemId, decimal quantity, Guid orderId, Guid cookId, CancellationToken cancellationToken = default);
}