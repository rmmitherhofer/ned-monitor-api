using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NedMonitor.Domain.Entities;
using Zypher.Domain.Core.Enums;
using Zypher.Logs.Extensions;
using Zypher.Notifications.Interfaces;
using Zypher.Persistence.Abstractions.Data;

namespace NedMonitor.Infra.Data;

public class NedMonitorContext : DbContext, IUnitOfWork
{
    private const string RegistrationDate = nameof(RegistrationDate);
    private const string DateChanged = nameof(DateChanged);
    private readonly ILogger<NedMonitorContext> _logger;

    private readonly INotificationHandler _notification;

    public NedMonitorContext(DbContextOptions<NedMonitorContext> options, INotificationHandler notification, ILogger<NedMonitorContext> logger) : base(options)
    {
        _logger = logger;
        _notification = notification;
    }

    public virtual DbSet<ApplicationLog> Logs { get; set; }
    public virtual DbSet<Domain.Entities.Exception> Exceptions { get; set; }
    public virtual DbSet<LogEntry> Entries { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }
    public virtual DbSet<HttpClientLog> HttpClientLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e =>
                e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
        {
            property.SetColumnType("varchar(150)");
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NedMonitorContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Cascade;
        }

        base.OnModelCreating(modelBuilder);
    }

    public async Task<(bool, OperationType)> Commit()
    {
        var operationType = ValidateChange();

        var success = await SaveChangesAsync();

        return (success, operationType);
    }

    private async Task<bool> SaveChangesAsync()
    {
        var success = false;
        try
        {
            if (_notification.HasNotifications()) return success;

            success = await base.SaveChangesAsync() > 0;
        }
        catch (System.Exception ex)
        {
            _notification.Notify(new Zypher.Notifications.Messages.Notification(LogLevel.Critical, ex.GetType().Name, "SQL-Server", ex.InnerException is null ? ex.Message : ex.InnerException.Message));

            _logger.LogCrit(ex.InnerException is null ? ex.Message : ex.InnerException.Message);
        }
        return success;
    }
    private OperationType ValidateChange()
    {
        OperationType operationType = OperationType.None;
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(RegistrationDate) != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(RegistrationDate).CurrentValue = DateTime.Now;
                operationType = OperationType.Added;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(RegistrationDate).IsModified = false;

                entry.Property(DateChanged).CurrentValue = DateTime.Now;

                operationType = OperationType.Modified;
            }

            if (entry.State == EntityState.Deleted)
                operationType = OperationType.Deleted;
        }
        return operationType;
    }


}
