using Buildings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SensorAccounting.EntityConfiguration;

public class SensorConfig : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Description)
            .HasMaxLength(500);

        builder.Property(s => s.UrlPhoto)
            .HasMaxLength(200);

        builder.Property(s => s.ChargeLevel)
            .IsRequired();

        builder.OwnsOne(s => s.Location, loc =>
        {
            loc.Property(l => l.X).HasColumnName("LocationX").IsRequired();
            loc.Property(l => l.Y).HasColumnName("LocationY").IsRequired();
        });

        builder.Property(s => s.Temperature)
            .IsRequired();

        builder.Property(s => s.MaxTemperature)
            .IsRequired();

        builder.Property(s => s.MinTemperature)
            .IsRequired();

        builder.Property(s => s.IdBuilding)
            .IsRequired();
        
        builder.HasOne(s => s.Building)
            .WithMany(b => b.Sensors)
            .HasForeignKey(s => s.IdBuilding)
            .OnDelete(DeleteBehavior.Cascade);
    }
}