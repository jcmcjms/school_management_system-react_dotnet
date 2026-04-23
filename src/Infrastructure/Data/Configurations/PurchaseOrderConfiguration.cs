using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
    {
        builder.HasIndex(po => po.SupplierId).HasDatabaseName("IX_PurchaseOrder_SupplierId");
        builder.HasIndex(po => po.Status).HasDatabaseName("IX_PurchaseOrder_Status");
        builder.HasIndex(po => po.OrderDate).HasDatabaseName("IX_PurchaseOrder_OrderDate");

        builder.Property(po => po.TotalAmount).HasColumnType("decimal(18,2)");

        builder.HasOne(po => po.Supplier)
            .WithMany(s => s.PurchaseOrders)
            .HasForeignKey(po => po.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(po => po.Items)
            .WithOne(i => i.PurchaseOrder)
            .HasForeignKey(i => i.PurchaseOrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}