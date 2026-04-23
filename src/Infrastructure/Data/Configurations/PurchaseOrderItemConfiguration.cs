using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class PurchaseOrderItemConfiguration : IEntityTypeConfiguration<PurchaseOrderItem>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
    {
        builder.Property(poi => poi.Quantity).HasColumnType("decimal(18,2)");
        builder.Property(poi => poi.UnitPrice).HasColumnType("decimal(18,2)");
        builder.Property(poi => poi.TotalPrice).HasColumnType("decimal(18,2)");

        builder.HasOne(poi => poi.PurchaseOrder)
            .WithMany(po => po.Items)
            .HasForeignKey(poi => poi.PurchaseOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(poi => poi.InventoryItem)
            .WithMany(ii => ii.PurchaseOrderItems)
            .HasForeignKey(poi => poi.InventoryItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}