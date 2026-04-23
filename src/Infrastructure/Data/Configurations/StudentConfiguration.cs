using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasIndex(s => s.UserId).IsUnique().HasDatabaseName("IX_Student_UserId_Unique");
        builder.HasIndex(s => s.RollNumber).HasDatabaseName("IX_Student_RollNumber");
        builder.HasIndex(s => s.ParentId).HasDatabaseName("IX_Student_ParentId");

        builder.Property(s => s.RollNumber).HasMaxLength(50);
        builder.Property(s => s.Grade).HasMaxLength(50);
        builder.Property(s => s.Section).HasMaxLength(50);

        builder.HasOne(s => s.User)
            .WithOne(u => u.Student)
            .HasForeignKey<Student>(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Parent)
            .WithMany(p => p.Children)
            .HasForeignKey(s => s.ParentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}