using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NedMonitor.Domain.Entities;
using System.Text.Json;

namespace NedMonitor.Infra.Data.Mappings;

public class HttpClientLogMapping : IEntityTypeConfiguration<HttpClientLog>
{
    public void Configure(EntityTypeBuilder<HttpClientLog> builder)
    {
        builder.ToTable("HttpClientLogs");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.RegistrationDate)
            .IsRequired();

        builder.Property(c => c.DateChanged);

        builder.Property(x => x.StartTimeUtc)
            .IsRequired();

        builder.Property(x => x.EndTimeUtc)
            .IsRequired();

        builder.Property(x => x.Method)
            .HasMaxLength(10)
            .HasColumnType("varchar(10)")
            .IsRequired();

        builder.Property(x => x.UrlTemplate)
            .HasColumnType("nvarchar(2048)")
            .HasMaxLength(2048);

        builder.Property(x => x.Url)
            .HasMaxLength(2048)
            .HasColumnType("nvarchar(2048)")
            .IsRequired();

        builder.Property(x => x.StatusCode)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.RequestBody)
            .HasColumnType("varchar(max)");

        builder.Property(x => x.RequestBody)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<object>(v!, (JsonSerializerOptions?)null))
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.RequestHeaders)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<Dictionary<string, List<string>>>(v!, (JsonSerializerOptions?)null) ?? new Dictionary<string, List<string>>())
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.ResponseBody)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<object>(v!, (JsonSerializerOptions?)null))
            .HasColumnType("nvarchar(max)");

        builder.Property(rq => rq.ResponseHeaders)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<Dictionary<string, List<string>>>(v!, (JsonSerializerOptions?)null) ?? new Dictionary<string, List<string>>())
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.ExceptionType)
            .HasColumnType("nvarchar(500)")
            .HasMaxLength(500);

        builder.Property(x => x.ExceptionMessage)
            .HasColumnType("varchar(max)");

        builder.Property(x => x.StackTrace)
            .HasColumnType("varchar(max)");

        builder.Property(x => x.InnerException)
            .HasColumnType("varchar(max)");

        builder.Ignore(x => x.DurationInMilliseconds);

        builder.Property(x => x.LogId)
            .IsRequired();

        builder.Property(x => x.CorrelationId)
    .HasColumnType("nvarchar(100)")
    .HasMaxLength(100)
    .IsRequired();
    }
}