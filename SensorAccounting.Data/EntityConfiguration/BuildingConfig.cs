using Buildings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SensorAccounting.EntityConfiguration;

public class BuildingConfig : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("id_building");
        builder.Property(e => e.NameBuilding)
            .HasColumnName("name_building")
            .HasMaxLength(100);
        builder.Property(e => e.Address)
            .HasColumnName("adress")
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(e => e.Floor)
            .HasColumnName("floor")
            .IsRequired();
        builder.Property(e => e.IdPerson)
            .HasColumnName("id_person")
            .IsRequired();
        
        builder.HasMany(b => b.Sensors)
            .WithOne(s => s.Building)
            .HasForeignKey(s => s.IdBuilding)
            .OnDelete(DeleteBehavior.Cascade);
    }
}