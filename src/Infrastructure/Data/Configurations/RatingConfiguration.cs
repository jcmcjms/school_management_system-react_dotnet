using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.HasIndex(r => r.OrderItemId).IsUnique().HasDatabaseName("IX_Rating_OrderItemId_Unique");
        builder.HasIndex(r => r.UserId).HasDatabaseName("IX_Rating_UserId");
        builder.HasIndex(r => r.RatingValue).HasDatabaseName("IX_Rating_RatingValue");

        builder.Property(r => r.Comment).HasMaxLength(1000);

        builder.HasOne(r => r.OrderItem)
            .WithOne(oi => oi.Rating)
            .HasForeignKey<Rating>(r => r.OrderItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}