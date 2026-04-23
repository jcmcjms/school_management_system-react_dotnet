using Application.DTOs.Common;
using Application.DTOs.Orders;
using Domain.Enums;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<Result<OrderDto>> PlaceOrderAsync(Guid userId, PlaceOrderRequest request, CancellationToken cancellationToken = default);
    Task<Result<bool>> CancelOrderAsync(Guid orderId, Guid userId, CancellationToken cancellationToken = default);
    Task<OrderDto?> GetOrderByQrTokenAsync(string qrToken, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateOrderStatusAsync(Guid orderId, OrderStatus status, Guid updatedBy, CancellationToken cancellationToken = default);
    Task<PagedResult<OrderDto>> GetMyOrdersAsync(Guid userId, PaginationParams parameters, CancellationToken cancellationToken = default);
}