namespace Application.Interfaces;

public interface IAuditService
{
    Task LogActionAsync(
        string action,
        string entityType,
        Guid entityId,
        object? oldValues,
        object? newValues,
        Guid? userId,
        string? ipAddress,
        CancellationToken cancellationToken = default);
}