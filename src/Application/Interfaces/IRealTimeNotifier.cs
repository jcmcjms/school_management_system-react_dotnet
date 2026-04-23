namespace Application.Interfaces;

public interface IRealTimeNotifier
{
    Task NotifyNewOrderAsync(Guid orderId, string groupName);
    Task NotifyOrderStatusChangedAsync(Guid orderId, string status, Guid userId);
    Task NotifyOrderReadyAsync(Guid orderId, Guid userId);
    Task NotifyLowStockAsync(string itemName, decimal currentStock, string groupName);
}