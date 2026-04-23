using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.HasIndex(w => w.UserId).IsUnique().HasDatabaseName("IX_Wallet_UserId_Unique");

        builder.Property(w => w.Balance).HasColumnType("decimal(18,2)");
        builder.Property(w => w.DailyLimit).HasColumnType("decimal(18,2)");
        builder.Property(w => w.MonthlyLimit).HasColumnType("decimal(18,2)");

        builder.HasOne(w => w.User)
            .WithOne(u => u.Wallet)
            .HasForeignKey<Wallet>(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(w => w.Transactions)
            .WithOne(t => t.Wallet)
            .HasForeignKey(t => t.WalletId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}