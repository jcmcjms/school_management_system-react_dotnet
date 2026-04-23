using Application.DTOs.Common;
using Application.DTOs.Orders;

namespace Application.Interfaces;

public interface ICartService
{
    Task<Result<bool>> AddToCartAsync(Guid userId, CartItemDto item, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateCartItemAsync(Guid userId, Guid menuItemId, int quantity, CancellationToken cancellationToken = default);
    Task<Result<bool>> RemoveFromCartAsync(Guid userId, Guid menuItemId, CancellationToken cancellationToken = default);
    Task<List<CartItemDto>> GetCartAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Result<bool>> ClearCartAsync(Guid userId, CancellationToken cancellationToken = default);
}