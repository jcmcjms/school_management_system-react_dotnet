using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class MenuItemDietaryTagConfiguration : IEntityTypeConfiguration<MenuItemDietaryTag>
{
    public void Configure(EntityTypeBuilder<MenuItemDietaryTag> builder)
    {
        builder.HasKey(md => new { md.MenuItemId, md.DietaryTagId });

        builder.HasOne(md => md.MenuItem)
            .WithMany(m => m.DietaryTags)
            .HasForeignKey(md => md.MenuItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(md => md.DietaryTag)
            .WithMany(d => d.MenuItems)
            .HasForeignKey(md => md.DietaryTagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}