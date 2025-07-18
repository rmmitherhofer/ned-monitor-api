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

        builder.Property(c => c.StartTimeUtc)
            .IsRequired();

        builder.Property(c => c.EndTimeUtc)
            .IsRequired();

        builder.Property(x => x.LogAttentionLevel)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.CorrelationId)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(x => x.Path)
            .HasColumnType("nvarchar(max)")
            .IsRequired();

        builder.Property(x => x.TotalMilliseconds)
            .IsRequired();

        builder.Property(x => x.TraceIdentifier)
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(x => x.ErrorCategory)
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)")
            .IsRequired(false);

        builder.HasIndex(x => x.CorrelationId);
        //builder.HasIndex(x => x.Path);
        builder.HasIndex(x => x.ErrorCategory);

        builder.OwnsOne(x => x.Project, p =>
        {
            p.Property(p => p.Id)
                .IsRequired();

            p.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            p.Property(p => p.Type)
                .HasConversion<int>()
                .IsRequired();

            p.Property(p => p.MinimumLogLevel)
                .HasConversion<int>()
                .IsRequired();

            p.OwnsOne(x => x.ExecutionMode, em =>
            {
                em.Property(em => em.EnableNedMonitor)
                    .IsRequired();

                em.Property(em => em.EnableMonitorDbQueries)
                    .IsRequired();

                em.Property(em => em.EnableMonitorLogs)
                    .IsRequired();

                em.Property(em => em.EnableMonitorExceptions)
                    .IsRequired();

                em.Property(em => em.EnableMonitorNotifications)
                    .IsRequired();

                em.Property(em => em.EnableMonitorHttpRequests)
                    .IsRequired();
            });

            p.OwnsOne(x => x.HttpLogging, hl =>
            {
                hl.Property(hl => hl.CaptureResponseBody)
                    .IsRequired();

                hl.Property(hl => hl.WritePayloadToConsole)
                    .IsRequired();

                hl.Property(hl => hl.MaxResponseBodySizeInMb)
                    .IsRequired();
            });

            p.OwnsOne(x => x.SensitiveDataMasking, sd =>
            {
                sd.Property(sd => sd.Enabled)
                    .IsRequired();

                sd.Property(sd => sd.SensitiveKeys)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                        v => JsonSerializer.Deserialize<List<string>>(v!, (JsonSerializerOptions?)null) ?? new())
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                sd.Property(sd => sd.MaskValue)
                    .HasColumnType("varchar(30)")
                    .IsRequired();
            });

            p.OwnsOne(x => x.Exceptions, e =>
            {
                e.Property(e => e.Expected)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                        v => JsonSerializer.Deserialize<List<string>>(v!, (JsonSerializerOptions?)null))
                    .HasColumnType("nvarchar(max)");
            });

            p.OwnsOne(x => x.DataInterceptors, di =>
            {
                di.Property(di => di.EF)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                        v => JsonSerializer.Deserialize<EfInterceptorSetting>(v!, (JsonSerializerOptions?)null))
                    .HasColumnType("nvarchar(max)");

                di.Property(di => di.Dapper)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                        v => JsonSerializer.Deserialize<DapperInterceptorSetting>(v!, (JsonSerializerOptions?)null))
                    .HasColumnType("nvarchar(max)");
            });

            p.HasIndex(p => p.Id);
            p.HasIndex(p => p.Name);
            p.HasIndex(p => p.Type);
        });

        builder.OwnsOne(x => x.Environment, e =>
        {
            e.Property(e => e.MachineName)
                .IsRequired()
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            e.Property(e => e.EnvironmentName)
                .IsRequired()
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            e.Property(e => e.ApplicationVersion)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            e.Property(e => e.ThreadId)
                .IsRequired();

            e.HasIndex(e => e.MachineName);
        });

        builder.OwnsOne(x => x.User, u =>
        {
            u.Property(u => u.Id)
                .HasColumnType("varchar(100)");

            u.Property(u => u.Name)
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);

            u.Property(u => u.AccountCode)
            .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            u.Property(u => u.Document)
            .HasColumnType("varchar(80)")
                .HasMaxLength(80);

            u.Property(u => u.Email)
            .HasColumnType("varchar(320)")
                .HasMaxLength(320);

            u.Property(u => u.TenantId)
            .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            u.Property(u => u.IsAuthenticated)
                .IsRequired();

            u.Property(u => u.AuthenticationType)
            .HasColumnType("nvarchar(100)")
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

        builder.OwnsOne(x => x.Request, rq =>
        {
            rq.Property(rq => rq.Id)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

            rq.Property(rq => rq.HttpMethod)
                .IsRequired()
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            rq.Property(rq => rq.RequestUrl)
                .IsRequired()
                .HasColumnType("nvarchar(1500)")
                .HasMaxLength(1500);

            rq.Property(rq => rq.Scheme)
                .IsRequired()
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            rq.Property(rq => rq.Protocol)
                .IsRequired()
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            rq.Property(rq => rq.IsHttps)
                .IsRequired();

            rq.Property(rq => rq.QueryString)
                .IsRequired()
                .HasColumnType("nvarchar(1350)")
                .HasMaxLength(1350);

            rq.Property(rq => rq.RouteValues)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<Dictionary<string, string>>(v!, (JsonSerializerOptions?)null) ?? new Dictionary<string, string>())
                .HasColumnType("nvarchar(max)");


            rq.OwnsOne(x => x.UserPlatform, up =>
            {
                up.Property(up => up.UserAgent)
                .HasColumnType("varchar(500)")
                    .HasMaxLength(500);

                up.Property(up => up.BrowserName)
                .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                up.Property(up => up.BrowserVersion)
                .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                up.Property(up => up.OSName)
                .HasColumnType("varchar(150)")
                    .HasMaxLength(150);

                up.Property(up => up.OSVersion)
                .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                up.Property(up => up.DeviceType)
                .HasColumnType("varchar(50)")
                    .HasMaxLength(50);
            });

            rq.Property(rq => rq.ClientId)
                .HasColumnType("nvarchar(250)")
                .HasMaxLength(250);

            rq.Property(rq => rq.Headers)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<Dictionary<string, List<string>>>(v!, (JsonSerializerOptions?)null) ?? new Dictionary<string, List<string>>())
                .HasColumnType("nvarchar(max)");

            rq.Property(rq => rq.ContentType)
            .HasColumnType("varchar(100)")
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
            .HasColumnType("varchar(45)")
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
            .HasColumnType("varchar(450)")
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
                    v => JsonSerializer.Deserialize<List<Dependency>>(v!, (JsonSerializerOptions?)null) ?? new List<Dependency>())
                .HasColumnType("nvarchar(max)");
        });

        builder.HasMany(c => c.Notifications)
            .WithOne(a => a.ApplicationLog)
            .HasForeignKey(a => a.LogId);

        builder.HasMany(c => c.LogEntries)
            .WithOne(a => a.ApplicationLog)
            .HasForeignKey(a => a.LogId);

        builder.HasMany(c => c.Exceptions)
            .WithOne(a => a.ApplicationLog)
            .HasForeignKey(a => a.LogId);

        builder.HasMany(c => c.DbQueryEntries)
            .WithOne(a => a.ApplicationLog)
            .HasForeignKey(a => a.LogId);

        builder.HasMany(c => c.HttpClientLogs)
            .WithOne(a => a.ApplicationLog)
            .HasForeignKey(a => a.LogId);
    }
}
