using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class FacultyStaff: BaseEntity
{
    public Guid UserId { get; set; }
    [MaxLength(50)]
    public string EmployeeId { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Department { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Designation { get; set; } = string.Empty;
    public bool SalaryDeductionEnabled { get; set; } = false;
    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;
}