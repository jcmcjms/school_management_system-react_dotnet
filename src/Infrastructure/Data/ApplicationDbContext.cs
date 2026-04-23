using System.Reflection;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Parent> Parents => Set<Parent>();
    public DbSet<FacultyStaff> FacultyStaff => Set<FacultyStaff>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<DietaryTag> DietaryTags=> Set<DietaryTag>();
    public DbSet<MenuSchedule> MenuSchedules => Set<MenuSchedule>();
    public DbSet<CanteenSettings> CanteenSettings => Set<CanteenSettings>();
    public DbSet<Wallet> Wallets => Set<Wallet>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<InventoryTransaction> InventoryTransactions => Set<InventoryTransaction>();
    public DbSet<WasteLog> WasteLogs => Set<WasteLog>();
    public DbSet<IngredientRequest> IngredientRequests => Set<IngredientRequest>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderItem> PurchaseOrderItems => Set<PurchaseOrderItem>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Rating> Ratings => Set<Rating>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Apply all configurations from this assembly
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // Apply global query filter for soft delete on all BaseEntity types
        var entityTypes = builder.Model.GetEntityTypes()
        .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType) && !e.ClrType.IsAbstract);
        foreach (var entityType in entityTypes)
        {
            var method = typeof(ApplicationDbContext)
            .GetMethod(nameof(ApplySoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)!.MakeGenericMethod(entityType.ClrType);
            method.Invoke(null, new object[] { builder });
        }
         // Seed CanteenSettings (single row)
        builder.Entity<CanteenSettings>().HasData(new CanteenSettings
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            OpeningTime = new TimeOnly(7, 0),
            ClosingTime = new TimeOnly(18, 0),
            PreOrderDeadline = new TimeOnly(9, 0),
            MaxDailyOrderLimit = 500,
            AllowWalkInOrders = true,
            StaffDiscountPercent = 10,
            StudentDiscountPercent = 5,
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        });
    }

    private static void ApplySoftDeleteFilter<T>(ModelBuilder builder) where T: BaseEntity
    {
        builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
    }

    public async Task SeedAsync(IServiceProvider serviceProvider)
    {
        if (await Users.AnyAsync()) return;

        var roleManger = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        // Create roles
        var roles = Enum.GetValues<UserRole>();
        foreach (var role in roles)
        {
            if (!await roleManger.RoleExistsAsync(role.ToString()))
            {
                await roleManger.CreateAsync(new IdentityRole<Guid>(role.ToString()));
            }
        }
        // Create admin user
        var adminUser = new ApplicationUser
        {
            UserName = "admin@school.com",
            Email = "admin@school.com",
            FirstName = "System",
            LastName = "Administrator",
            Role = UserRole.Admin,
            EmailConfirmed = true,
            CreatedAt = DateTime.UtcNow
        };
        
        var result = await userManager.CreateAsync(adminUser, "Admin123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, UserRole.Admin.ToString());
        }
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.IsDeleted = false;
                break;
                case EntityState.Modified:
                entry.Entity.UpdatedAt = DateTime.UtcNow;
                break;
                case EntityState.Deleted:
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
                break;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}