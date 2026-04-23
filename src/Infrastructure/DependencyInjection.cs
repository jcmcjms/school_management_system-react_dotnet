using Application.Interfaces;
using Domain.Entities;
using Hangfire;
using Infrastructure.Cache;
using Infrastructure.Data;
using Infrastructure.Email;
using Infrastructure.Identity;
using Infrastructure.Repositories;
using Infrastructure.SignalR;
using Infrastructure.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(
        IServiceCollection services,
        IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("Infrastructure");
                    sqlOptions.EnableRetryOnFailure(3);
                }));

        // Identity
        services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        // JWT Token Service
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        // Repositories & Unit of Work
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Redis
        var redisConnection = configuration.GetConnectionString("Redis") ?? "localhost:6379";
        services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConnection));
        services.AddScoped<IRedisCacheService, RedisCacheService>();

        // SignalR
        services.AddSignalR()
            .AddStackExchangeRedis(redisConnection, options =>
            {
                options.Configuration.ChannelPrefix = "CanteenHub";
            });

        services.AddScoped<IRealTimeNotifier, SignalRNotifier>();

        // Hangfire
        services.AddHangfire(config =>
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));

        services.AddHangfireServer(options =>
        {
            options.WorkerCount = 2;
            options.Queues = new[] { "default", "critical" };
        });

        // Email
        services.AddScoped<IEmailService, SmtpEmailService>();

        // File Storage
        services.AddScoped<IFileStorageService, LocalFileStorageService>();

        return services;
    }
}