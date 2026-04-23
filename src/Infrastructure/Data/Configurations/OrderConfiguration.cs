using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasIndex(o => o.UserId).HasDatabaseName("IX_Order_UserId");
        builder.HasIndex(o => o.Status).HasDatabaseName("IX_Order_Status");
        builder.HasIndex(o => o.OrderedAt).HasDatabaseName("IX_Order_OrderedAt");
        builder.HasIndex(o => o.OrderNumber).IsUnique().HasDatabaseName("IX_Order_OrderNumber_Unique");

        builder.Property(o => o.OrderNumber).HasMaxLength(50);
        builder.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(o => o.DiscountAmount).HasColumnType("decimal(18,2)");
        builder.Property(o => o.FinalAmount).HasColumnType("decimal(18,2)");
        builder.Property(o => o.QrToken).HasMaxLength(500);

        builder.HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(o => o.Transactions)
            .WithOne(t => t.Order)
            .HasForeignKey(t => t.OrderId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}