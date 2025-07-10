using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NedMonitor.Domain.Entities;

namespace NedMonitor.Infra.Data.Mappings;

public class NotificationMapping : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.RegistrationDate)
            .IsRequired();

        builder.Property(c => c.DateChanged);

        builder.Property(x => x.Timestamp)
            .IsRequired();

        builder.Property(x => x.LogLevel)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Key)
            .HasMaxLength(350);

        builder.Property(x => x.Value)
            .IsRequired()
            .HasColumnType("VARCHAR(MAX)");

        builder.Property(x => x.Detail)
            .HasColumnType("VARCHAR(MAX)");

        builder.Property(x => x.LogId)
            .IsRequired();

        builder.HasOne(x => x.ApplicationLog)
            .WithMany(x => x.Notifications)
            .HasForeignKey(x => x.LogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
