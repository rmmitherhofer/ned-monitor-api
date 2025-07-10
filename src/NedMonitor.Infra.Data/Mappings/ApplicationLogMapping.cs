using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NedMonitor.Domain.Entities;
using System.Text.Json;

namespace NedMonitor.Infra.Data.Mappings;

public class ApplicationLogMapping : IEntityTypeConfiguration<ApplicationLog>
{
    public void Configure(EntityTypeBuilder<ApplicationLog> builder)
    {
        builder.ToTable("ApplicationLogs");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.RegistrationDate)
            .IsRequired();

        builder.Property(c => c.DateChanged);

        builder.Property(x => x.LogAttentionLevel)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.CorrelationId)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.EndpointPath)
            .IsRequired()
            .HasMaxLength(9000);

        builder.Property(x => x.ElapsedMilliseconds)
            .IsRequired();

        builder.Property(x => x.TraceIdentifier)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(x => x.ErrorCategory)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.HasIndex(x => x.CorrelationId);
        builder.HasIndex(x => x.EndpointPath);
        builder.HasIndex(x => x.ErrorCategory);

        builder.OwnsOne(x => x.Project, p =>
        {
            p.Property(p => p.Id)
                .IsRequired()
                .HasMaxLength(200);

            p.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            p.Property(p => p.Type)
                .HasConversion<int>()
                .IsRequired();

            p.Property(p => p.ExecutionMode)
                .HasConversion<int>()
                .IsRequired();

            p.Property(p => p.MaxResponseBodySizeInMb)
                .IsRequired();

            p.Property(p => p.CaptureResponseBody)
                .IsRequired();

            p.Property(p => p.WritePayloadToConsole)
                .IsRequired();

            p.HasIndex(p => p.Id);
            p.HasIndex(p => p.Name);
            p.HasIndex(p => p.Type);
        });

        builder.OwnsOne(x => x.Environment, e =>
        {
            e.Property(e => e.MachineName)
                .IsRequired()
                .HasMaxLength(250);

            e.Property(e => e.EnvironmentName)
                .IsRequired()
                .HasMaxLength(250);

            e.Property(e => e.ApplicationVersion)
                .IsRequired()
                .HasMaxLength(100);

            e.Property(e => e.ThreadId)
                .IsRequired();

            e.HasIndex(e => e.MachineName);
        });

        builder.OwnsOne(x => x.User, u =>
        {
            u.Property(u => u.Id)
            .HasMaxLength(250);

            u.Property(u => u.Name)
                .HasMaxLength(450);

            u.Property(u => u.AccountCode)
                .HasMaxLength(250);

            u.Property(u => u.Document)
                .HasMaxLength(80);

            u.Property(u => u.Email)
                .HasMaxLength(320);

            u.Property(u => u.TenantId)
                .HasMaxLength(250);

            u.Property(u => u.IsAuthenticated)
                .IsRequired();

            u.Property(u => u.AuthenticationType)
                .HasMaxLength(100);

            u.Property(u => u.Roles)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<string>>(v!, (JsonSerializerOptions?)null) ?? new())
                .HasColumnType("nvarchar(max)");

            u.Property(u => u.Claims)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<Dictionary<string, string>>(v!, (JsonSerializerOptions?)null) ?? new())
                .HasColumnType("nvarchar(max)");

            u.HasIndex(u => u.Id);
            u.HasIndex(u => u.Name);
            u.HasIndex(u => u.AccountCode);
            u.HasIndex(u => u.Document);
        });

        builder.OwnsOne(x => x.UserPlatform, up =>
        {
            up.Property(up => up.UserAgent)
                .HasMaxLength(500);

            up.Property(up => up.BrowserName)
                .HasMaxLength(100);

            up.Property(up => up.BrowserVersion)
                .HasMaxLength(50);

            up.Property(up => up.OSName)
                .HasMaxLength(150);

            up.Property(up => up.OSVersion)
                .HasMaxLength(50);

            up.Property(up => up.DeviceType)
                .HasMaxLength(50);
        });

        builder.OwnsOne(x => x.Request, rq =>
        {
            rq.Property(rq => rq.Id)
            .IsRequired()
            .HasMaxLength(50);

            rq.Property(rq => rq.HttpMethod)
                .IsRequired()
                .HasMaxLength(10);

            rq.Property(rq => rq.RequestUrl)
                .IsRequired()
                .HasMaxLength(1500);

            rq.Property(rq => rq.Scheme)
                .IsRequired()
                .HasMaxLength(20);

            rq.Property(rq => rq.Protocol)
                .IsRequired()
                .HasMaxLength(10);

            rq.Property(rq => rq.IsHttps)
                .IsRequired();

            rq.Property(rq => rq.QueryString)
                .IsRequired()
                .HasMaxLength(1350);

            rq.Property(rq => rq.RouteValues)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<Dictionary<string, string>>(v!, (JsonSerializerOptions?)null) ?? new Dictionary<string, string>())
                .HasColumnType("nvarchar(max)");

            rq.Property(rq => rq.UserAgent)
                .IsRequired()
                .HasMaxLength(1500);

            rq.Property(rq => rq.ClientId)
                .IsRequired()
                .HasMaxLength(250);

            rq.Property(rq => rq.Headers)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<Dictionary<string, List<string>>>(v!, (JsonSerializerOptions?)null) ?? new Dictionary<string, List<string>>())
                .HasColumnType("nvarchar(max)");

            rq.Property(rq => rq.ContentType)
                .HasMaxLength(100);

            rq.Property(rq => rq.ContentLength)
                .HasColumnType("bigint");

            rq.Property(rq => rq.Body)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<object>(v!, (JsonSerializerOptions?)null))
                .HasColumnType("nvarchar(max)");

            rq.Property(rq => rq.BodySize)
                .IsRequired();

            rq.Property(rq => rq.IsAjaxRequest)
                .IsRequired();

            rq.Property(rq => rq.IpAddress)
                .HasMaxLength(45);

            rq.HasIndex(rq => rq.Id);
            rq.HasIndex(rq => rq.ClientId);
        });

        builder.OwnsOne(x => x.Response, rp =>
        {
            rp.Property(rp => rp.StatusCode)
            .HasConversion<int>()
            .IsRequired();

            rp.Property(rp => rp.ReasonPhrase)
                .HasMaxLength(450);

            rp.Property(rp => rp.Headers)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<Dictionary<string, List<string>>>(v!, (JsonSerializerOptions?)null) ?? new Dictionary<string, List<string>>())
                .HasColumnType("nvarchar(max)");

            rp.Property(rp => rp.Body)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<object>(v!, (JsonSerializerOptions?)null))
                .HasColumnType("nvarchar(max)");

            rp.Property(rp => rp.BodySize)
                .IsRequired();
        });

        builder.OwnsOne(x => x.Diagnostic, d =>
        {
            d.Property(d => d.MemoryUsageMb)
                .IsRequired();

            d.Property(d => d.DbQueryCount)
                .IsRequired();

            d.Property(d => d.CacheHit)
                .IsRequired();

            d.Property(d => d.Dependencies)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<DependencyInfo>>(v!, (JsonSerializerOptions?)null) ?? new List<DependencyInfo>())
                .HasColumnType("nvarchar(max)");
        });

        builder.HasMany(c => c.Notifications)
            .WithOne(a => a.ApplicationLog)
            .HasForeignKey(a => a.LogId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.LogEntries)
            .WithOne(a => a.ApplicationLog)
            .HasForeignKey(a => a.LogId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Exceptions)
            .WithOne(a => a.ApplicationLog)
            .HasForeignKey(a => a.LogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
