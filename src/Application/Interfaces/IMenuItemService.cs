using Application.DTOs.Canteen;
using Application.DTOs.Common;

namespace Application.Interfaces;

public interface IMenuItemService
{
    Task<Result<MenuItemDto>> CreateAsync(CreateMenuItemRequest request, CancellationToken cancellationToken = default);
    Task<Result<MenuItemDto>> UpdateAsync(UpdateMenuItemRequest request, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<MenuItemDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PagedResult<MenuItemDto>> GetAllAsync(PaginationParams parameters, CancellationToken cancellationToken = default);
    Task<Result<bool>> ToggleAvailabilityAsync(Guid id, CancellationToken cancellationToken = default);
}