using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class FacultyStaffConfiguration : IEntityTypeConfiguration<FacultyStaff>
{
    public void Configure(EntityTypeBuilder<FacultyStaff> builder)
    {
        builder.HasIndex(fs => fs.UserId).IsUnique().HasDatabaseName("IX_FacultyStaff_UserId_Unique");
        builder.HasIndex(fs => fs.EmployeeId).HasDatabaseName("IX_FacultyStaff_EmployeeId");

        builder.Property(fs => fs.EmployeeId).HasMaxLength(50);
        builder.Property(fs => fs.Department).HasMaxLength(100);
        builder.Property(fs => fs.Designation).HasMaxLength(100);

        builder.HasOne(fs => fs.User)
            .WithOne(u => u.FacultyStaff)
            .HasForeignKey<FacultyStaff>(fs => fs.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}