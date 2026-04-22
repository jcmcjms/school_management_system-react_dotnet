using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class AuditLog : BaseEntity
{
    [MaxLength(100)]
    public string Action { get; set; } = string.Empty;

    [MaxLength(100)]
    public string EntityType { get; set; } = string.Empty;

    public Guid EntityId { get; set; }

    public string? OldValues { get; set; } // JSON string

    public string? NewValues { get; set; } // JSON string

    public Guid? UserId { get; set; }

    [MaxLength(50)]
    public string? IpAddress { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}