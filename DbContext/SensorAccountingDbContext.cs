using System.Reflection;
using Buildings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SensorAccounting.DbContext;

public class SensorAccountingDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public SensorAccountingDbContext(DbContextOptions<SensorAccountingDbContext> options)
        : base(options)
    {
    }

    public SensorAccountingDbContext()
    {
    }
    
    public DbSet<Sensor> Sensors => Set<Sensor>();
    public DbSet<Building?> Buildings => Set<Building>();
    public DbSet<Person?> Persons => Set<Person>();
    public DbSet<Notification> Notifications => Set<Notification>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "DbContext");
        var appSettingsPath = Path.Combine(basePath, "appsettings.json");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile(appSettingsPath)
            .Build();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            .LogTo(Console.WriteLine, LogLevel.Information);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}