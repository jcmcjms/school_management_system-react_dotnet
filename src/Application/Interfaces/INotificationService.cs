using Application.DTOs.Common;
using Application.DTOs.Notifications;

namespace Application.Interfaces;

public interface INotificationService
{
    Task<Result<bool>> CreateAsync(Guid userId, string type, string title, string message, string? actionUrl = null, CancellationToken cancellationToken = default);
    Task<Result<bool>> MarkAsReadAsync(Guid notificationId, Guid userId, CancellationToken cancellationToken = default);
    Task<Result<bool>> MarkAllAsReadAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<int> GetUnreadCountAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<PagedResult<NotificationDto>> GetMyNotificationsAsync(Guid userId, PaginationParams parameters, CancellationToken cancellationToken = default);
    Task SendPushNotificationAsync(Guid userId, string title, string message, CancellationToken cancellationToken = default);
    Task SendEmailAsync(Guid userId, string subject, string body, bool isHtml = false, CancellationToken cancellationToken = default);
}