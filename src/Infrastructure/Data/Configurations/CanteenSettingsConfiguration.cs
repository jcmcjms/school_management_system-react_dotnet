using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class CanteenSettingsConfiguration : IEntityTypeConfiguration<CanteenSettings>
{
    public void Configure(EntityTypeBuilder<CanteenSettings> builder)
    {
        builder.HasIndex(cs => cs.Id).IsUnique().HasDatabaseName("IX_CanteenSettings_Id_Unique");

        builder.Property(cs => cs.StaffDiscountPercent).HasColumnType("decimal(18,2)");
        builder.Property(cs => cs.StudentDiscountPercent).HasColumnType("decimal(18,2)");
    }
}