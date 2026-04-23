using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class IngredientRequestConfiguration : IEntityTypeConfiguration<IngredientRequest>
{
    public void Configure(EntityTypeBuilder<IngredientRequest> builder)
    {
        builder.HasIndex(ir => ir.InventoryItemId).HasDatabaseName("IX_IngredientRequest_ItemId");
        builder.HasIndex(ir => ir.Status).HasDatabaseName("IX_IngredientRequest_Status");
        builder.HasIndex(ir => ir.RequestedBy).HasDatabaseName("IX_IngredientRequest_RequestedBy");

        builder.Property(ir => ir.QuantityNeeded).HasColumnType("decimal(18,2)");
        builder.Property(ir => ir.Urgency).HasMaxLength(20);
        builder.Property(ir => ir.Status).HasMaxLength(20);

        builder.HasOne(ir => ir.InventoryItem)
            .WithMany(ii => ii.IngredientRequests)
            .HasForeignKey(ir => ir.InventoryItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}