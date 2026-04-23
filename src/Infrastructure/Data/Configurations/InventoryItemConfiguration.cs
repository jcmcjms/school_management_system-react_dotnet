using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.HasIndex(i => i.Name).HasDatabaseName("IX_InventoryItem_Name");
        builder.HasIndex(i => i.Category).HasDatabaseName("IX_InventoryItem_Category");
        builder.HasIndex(i => i.SupplierId).HasDatabaseName("IX_InventoryItem_SupplierId");

        builder.Property(i => i.CurrentStock).HasColumnType("decimal(18,2)");
        builder.Property(i => i.MinStockLevel).HasColumnType("decimal(18,2)");
        builder.Property(i => i.ReorderPoint).HasColumnType("decimal(18,2)");
        builder.Property(i => i.CostPerUnit).HasColumnType("decimal(18,2)");
        builder.Property(i => i.Name).HasMaxLength(200);
        builder.Property(i => i.Category).HasMaxLength(100);
        builder.Property(i => i.UnitOfMeasure).HasMaxLength(50);

        builder.HasOne(i => i.Supplier)
            .WithMany(s => s.InventoryItems)
            .HasForeignKey(i => i.SupplierId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}