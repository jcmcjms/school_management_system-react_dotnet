using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class InventoryTransactionConfiguration : IEntityTypeConfiguration<InventoryTransaction>
{
    public void Configure(EntityTypeBuilder<InventoryTransaction> builder)
    {
        builder.HasIndex(it => it.InventoryItemId).HasDatabaseName("IX_InventoryTransaction_ItemId");
        builder.HasIndex(it => it.Type).HasDatabaseName("IX_InventoryTransaction_Type");
        builder.HasIndex(it => new { it.ReferenceOrderId, it.ReferencePurchaseOrderId })
            .HasDatabaseName("IX_InventoryTransaction_References");

        builder.Property(it => it.Quantity).HasColumnType("decimal(18,2)");
        builder.Property(it => it.Reason).HasMaxLength(500);

        builder.HasOne(it => it.InventoryItem)
            .WithMany(ii => ii.Transactions)
            .HasForeignKey(it => it.InventoryItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}