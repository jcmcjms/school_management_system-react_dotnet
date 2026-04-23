using Application.DTOs.Common;
using Application.DTOs.Inventory;

namespace Application.Interfaces;

public interface IInventoryService
{
    Task<Result<InventoryItemDto>> CreateInventoryItemAsync(CreateInventoryItemRequest request, CancellationToken cancellationToken = default);
    Task<Result<InventoryItemDto>> UpdateInventoryItemAsync(Guid id, CreateInventoryItemRequest request, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteInventoryItemAsync(Guid id, CancellationToken cancellationToken = default);
    Task<InventoryItemDto?> GetInventoryItemByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PagedResult<InventoryItemDto>> GetInventoryItemsAsync(PaginationParams parameters, CancellationToken cancellationToken = default);
    Task<Result<bool>> LogWasteAsync(CreateWasteLogRequest request, Guid loggedBy, CancellationToken cancellationToken = default);
    Task<Result<PurchaseOrderDto>> CreatePurchaseOrderAsync(CreatePurchaseOrderRequest request, Guid createdBy, CancellationToken cancellationToken = default);
    Task<Result<bool>> ApprovePurchaseOrderAsync(Guid purchaseOrderId, Guid approvedBy, CancellationToken cancellationToken = default);
    Task<Result<bool>> ReceivePurchaseOrderAsync(Guid purchaseOrderId, Guid receivedBy, CancellationToken cancellationToken = default);
    Task<PagedResult<InventoryItemDto>> GetLowStockItemsAsync(PaginationParams parameters, CancellationToken cancellationToken = default);
}