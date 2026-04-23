using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasIndex(n => n.UserId).HasDatabaseName("IX_Notification_UserId");
        builder.HasIndex(n => n.IsRead).HasDatabaseName("IX_Notification_IsRead");
        builder.HasIndex(n => n.SentAt).HasDatabaseName("IX_Notification_SentAt");

        builder.Property(n => n.Type).HasMaxLength(50);
        builder.Property(n => n.Title).HasMaxLength(200);
        builder.Property(n => n.Message).HasMaxLength(1000);
        builder.Property(n => n.ActionUrl).HasMaxLength(500);

        builder.HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}