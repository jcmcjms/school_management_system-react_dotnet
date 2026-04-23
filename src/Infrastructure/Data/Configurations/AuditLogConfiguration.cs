using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.HasIndex(al => al.EntityType).HasDatabaseName("IX_AuditLog_EntityType");
        builder.HasIndex(al => al.EntityId).HasDatabaseName("IX_AuditLog_EntityId");
        builder.HasIndex(al => al.UserId).HasDatabaseName("IX_AuditLog_UserId");
        builder.HasIndex(al => al.Timestamp).HasDatabaseName("IX_AuditLog_Timestamp");

        builder.Property(al => al.Action).HasMaxLength(100);
        builder.Property(al => al.EntityType).HasMaxLength(100);
        builder.Property(al => al.IpAddress).HasMaxLength(50);
    }
}