namespace Domain.Common;

public abstract class BaseEvent
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    public abstract string EventType { get; }
    public bool IsPublished { get; set; } = false;
}