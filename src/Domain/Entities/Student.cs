using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class Student: BaseEntity
{
    public Guid UserId { get; set; }
    public string RollNumber { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public Guid? ParentId { get; set; }
    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;
    [ForeignKey(nameof(ParentId))]
    public virtual Parent? Parent { get; set; }
}