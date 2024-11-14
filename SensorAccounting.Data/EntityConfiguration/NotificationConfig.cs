using Buildings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SensorAccounting.EntityConfiguration;

public class NotificationConfig : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.Property(n => n.Date)
            .IsRequired();

        builder.Property(n => n.Message)
            .IsRequired()
            .HasMaxLength(500); // Максимальная длина текста уведомления

        builder.Property(n => n.IdSensor)
            .IsRequired();
        
        builder.HasOne<Sensor>()
            .WithMany(s => s.Notifications)
            .HasForeignKey(n => n.IdSensor)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}