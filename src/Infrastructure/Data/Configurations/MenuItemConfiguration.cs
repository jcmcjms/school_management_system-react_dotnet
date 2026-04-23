using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.HasIndex(m => m.Name).HasDatabaseName("IX_MenuItem_Name");
        builder.HasIndex(m => m.Category).HasDatabaseName("IX_MenuItem_Category");
        builder.HasIndex(m => m.IsAvailable).HasDatabaseName("IX_MenuItem_IsAvailable");
        
        builder.Property(m => m.Name).HasMaxLength(200);
        builder.Property(m => m.Description).HasMaxLength(1000);
        builder.Property(m => m.ImageUrl).HasMaxLength(500);
        builder.Property(m => m.Price).HasColumnType("decimal(18,2)");
        builder.Property(m => m.CostPrice).HasColumnType("decimal(18,2)");

        builder.HasMany(m => m.DietaryTags)
            .WithOne(d => d.MenuItem)
            .HasForeignKey(d => d.MenuItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.MenuSchedules)
            .WithOne(s => s.MenuItem)
            .HasForeignKey(s => s.MenuItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.OrderItems)
            .WithOne(oi => oi.MenuItem)
            .HasForeignKey(oi => oi.MenuItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}