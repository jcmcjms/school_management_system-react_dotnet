using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class Parent: BaseEntity
{
    public Guid UserId { get; set; }
    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;
    public virtual ICollection<Student> Children { get; set; } = new List<Student>();
}