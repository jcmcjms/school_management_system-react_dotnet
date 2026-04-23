using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class WasteLogConfiguration : IEntityTypeConfiguration<WasteLog>
{
    public void Configure(EntityTypeBuilder<WasteLog> builder)
    {
        builder.HasIndex(wl => wl.InventoryItemId).HasDatabaseName("IX_WasteLog_ItemId");
        builder.HasIndex(wl => wl.LoggedBy).HasDatabaseName("IX_WasteLog_LoggedBy");
        builder.HasIndex(wl => wl.LoggedAt).HasDatabaseName("IX_WasteLog_LoggedAt");

        builder.Property(wl => wl.Quantity).HasColumnType("decimal(18,2)");
        builder.Property(wl => wl.Reason).HasMaxLength(500);

        builder.HasOne(wl => wl.InventoryItem)
            .WithMany(ii => ii.WasteLogs)
            .HasForeignKey(wl => wl.InventoryItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}