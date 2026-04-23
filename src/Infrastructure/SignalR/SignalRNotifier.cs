using Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.SignalR;

public class SignalRNotifier : IRealTimeNotifier
{
    private readonly IHubContext<CanteenHub> _hubContext;

    public SignalRNotifier(IHubContext<CanteenHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NotifyNewOrderAsync(Guid orderId, string groupName = "kitchen")
    {
        await _hubContext.Clients.Group(groupName)
            .SendAsync("order:new", new { orderId, timestamp = DateTime.UtcNow });
    }

    public async Task NotifyOrderStatusChangedAsync(Guid orderId, string status, Guid userId)
    {
        await _hubContext.Clients.Group($"student-{userId}")
            .SendAsync("order:status-changed", new { orderId, status, timestamp = DateTime.UtcNow });
    }

    public async Task NotifyOrderReadyAsync(Guid orderId, Guid userId)
    {
        await _hubContext.Clients.Group($"student-{userId}")
            .SendAsync("order:ready", new { orderId, message = "Your order is ready for pickup!", timestamp = DateTime.UtcNow });
    }

    public async Task NotifyLowStockAsync(string itemName, decimal currentStock, string groupName = "manager")
    {
        await _hubContext.Clients.Group(groupName)
            .SendAsync("inventory:low-stock", new { itemName, currentStock, timestamp = DateTime.UtcNow });
    }
}