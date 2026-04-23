using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.Student;

    public bool IsActive { get; set; } = true;

    public DateTime? LastLoginAt { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public virtual Student? Student { get; set; }
    public virtual Parent? Parent { get; set; }
    public virtual FacultyStaff? FacultyStaff { get; set; }
    public virtual Wallet? Wallet { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}