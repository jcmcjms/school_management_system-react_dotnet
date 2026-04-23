using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasIndex(t => t.WalletId).HasDatabaseName("IX_Transaction_WalletId");
        builder.HasIndex(t => t.CreatedAt).HasDatabaseName("IX_Transaction_CreatedAt");
        builder.HasIndex(t => t.ReferenceNumber).IsUnique().HasDatabaseName("IX_Transaction_ReferenceNumber_Unique");

        builder.Property(t => t.Amount).HasColumnType("decimal(18,2)");
        builder.Property(t => t.BalanceAfter).HasColumnType("decimal(18,2)");
        builder.Property(t => t.ReferenceNumber).HasMaxLength(100);
        builder.Property(t => t.Description).HasMaxLength(500);
    }
}