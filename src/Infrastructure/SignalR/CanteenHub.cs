using System.Security.Claims;
using Domain.Enums;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.SignalR;

public class CanteenHub : Hub
{
    public async Task JoinKitchenGroup(string groupName = "kitchen")
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task JoinCashierGroup(string groupName = "cashier")
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task JoinStudentGroup(string userId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"student-{userId}");
    }

    public async Task JoinManagerGroup(string groupName = "manager")
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public override async Task OnConnectedAsync()
    {
        var userRole = Context.User?.FindFirst(ClaimTypes.Role)?.Value;
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!string.IsNullOrEmpty(userRole))
        {
            switch (userRole)
            {
                case nameof(UserRole.CanteenCook):
                    await JoinKitchenGroup();
                    break;
                case nameof(UserRole.CanteenCashier):
                    await JoinCashierGroup();
                    break;
                case nameof(UserRole.CanteenManager):
                    await JoinKitchenGroup();
                    await JoinCashierGroup();
                    await JoinManagerGroup();
                    break;
                case nameof(UserRole.Student):
                case nameof(UserRole.Parent):
                    if (!string.IsNullOrEmpty(userId))
                        await JoinStudentGroup(userId);
                    break;
            }
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userRole = Context.User?.FindFirst(ClaimTypes.Role)?.Value;
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!string.IsNullOrEmpty(userRole))
        {
            switch (userRole)
            {
                case nameof(UserRole.CanteenCook):
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "kitchen");
                    break;
                case nameof(UserRole.CanteenCashier):
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "cashier");
                    break;
                case nameof(UserRole.CanteenManager):
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "kitchen");
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "cashier");
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "manager");
                    break;
                case nameof(UserRole.Student):
                case nameof(UserRole.Parent):
                    if (!string.IsNullOrEmpty(userId))
                        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"student-{userId}");
                    break;
            }
        }

        await base.OnDisconnectedAsync(exception);
    }
}