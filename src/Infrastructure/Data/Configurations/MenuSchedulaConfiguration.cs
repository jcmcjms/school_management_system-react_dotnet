using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class MenuScheduleConfiguration : IEntityTypeConfiguration<MenuSchedule>
{
    public void Configure(EntityTypeBuilder<MenuSchedule> builder)
    {
        builder.HasIndex(ms => new { ms.Date, ms.MealType, ms.IsActive })
            .HasDatabaseName("IX_MenuSchedule_Date_MealType_IsActive");

        builder.HasIndex(ms => ms.MenuItemId).HasDatabaseName("IX_MenuSchedule_MenuItemId");

        builder.Property(ms => ms.SpecialPrice).HasColumnType("decimal(18,2)");

        builder.HasOne(ms => ms.MenuItem)
            .WithMany(m => m.MenuSchedules)
            .HasForeignKey(ms => ms.MenuItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}