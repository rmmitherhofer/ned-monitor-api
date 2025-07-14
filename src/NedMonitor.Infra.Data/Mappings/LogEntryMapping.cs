using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NedMonitor.Domain.Entities;

namespace NedMonitor.Infra.Data.Mappings;

public class LogEntryMapping : IEntityTypeConfiguration<LogEntry>
{
    public void Configure(EntityTypeBuilder<LogEntry> builder)
    {
        builder.ToTable("LogEntries");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.RegistrationDate)
            .IsRequired();

        builder.Property(c => c.DateChanged);

        builder.Property(x => x.TimestampUtc)
            .IsRequired();

        builder.Property(x => x.LogCategory)
            .HasMaxLength(4000);

        builder.Property(x => x.LogMessage)
            .HasColumnType("VARCHAR(MAX)");

        builder.Property(x => x.MemberName)
            .HasMaxLength(450); 

        builder.Property(x => x.SourceLineNumber);

        builder.Property(x => x.LogId)
            .IsRequired();

        builder.Property(x => x.CorrelationId)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(x => x.ApplicationLog)
            .WithMany(x => x.LogEntries)
            .HasForeignKey(x => x.LogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
