using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace NedMonitor.Infra.Data.Mappings;

public class DbQueryEntryMapping : IEntityTypeConfiguration<DbQueryEntry>
{
    public void Configure(EntityTypeBuilder<DbQueryEntry> builder)
    {
        builder.ToTable("DbQueryEntries");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.RegistrationDate)
            .IsRequired();

        builder.Property(c => c.DateChanged);

        builder.Property(x => x.Provider)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Sql)
            .HasColumnType("VARCHAR(MAX)");


        builder.Property(x => x.Parameters)
            .HasColumnType("VARCHAR(MAX)");

        builder.Property(x => x.ExecutedAtUtc)
            .IsRequired();

        builder.Property(x => x.DurationMs)
            .IsRequired();

        builder.Property(x => x.Success)
            .IsRequired();

        builder.Property(x => x.ExceptionMessage)
            .HasColumnType("VARCHAR(MAX)");

        builder.Property(x => x.DbContext)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<Dictionary<string, string>>(v!, (JsonSerializerOptions?)null))
            .HasColumnType("VARCHAR(MAX)");

        builder.Property(x => x.ORM)
            .HasColumnType("nvarchar(60)")
            .IsRequired();

        builder.Property(x => x.LogId)
            .IsRequired();

        builder.Property(x => x.CorrelationId)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100)
            .IsRequired();
    }
}
