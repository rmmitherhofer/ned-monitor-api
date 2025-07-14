using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NedMonitor.Infra.Data.Mappings;

public class ExceptionMapping : IEntityTypeConfiguration<Domain.Entities.Exception>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Exception> builder)
    {
        builder.ToTable("Exceptions");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.RegistrationDate)
            .IsRequired();

        builder.Property(c => c.DateChanged);

        builder.Property(c => c.TimestampUtc)
            .IsRequired();

        builder.Property(c => c.Source)
            .HasMaxLength(250);

        builder.Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Message)
            .IsRequired()
            .HasColumnType("varchar(max)");

        builder.Property(x => x.Tracer)
            .HasColumnType("varchar(max)");

        builder.Property(x => x.InnerException)
            .HasColumnType("varchar(max)");

        builder.Property(x => x.LogId)
            .IsRequired();

        builder.HasOne(x => x.ApplicationLog)
            .WithMany(x => x.Exceptions)
            .HasForeignKey(x => x.LogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
