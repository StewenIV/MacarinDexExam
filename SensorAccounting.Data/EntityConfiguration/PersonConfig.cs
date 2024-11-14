using Buildings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SensorAccounting.EntityConfiguration;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("id_person");
        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(100);
        builder.Property(e => e.Surname)
            .HasColumnName("surname")
            .HasMaxLength(100);
        builder.Property(e => e.PhoneNumber)
            .HasColumnName("phone_number")
            .HasMaxLength(20);
        builder.Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(100);
        builder.Property(e => e.Age)
            .HasColumnName("age")
            .IsRequired();

        builder.HasMany(p => p.Buildings)
            .WithOne(b => b.Person)
            .HasForeignKey(b => b.IdPerson)
            .OnDelete(DeleteBehavior.Cascade);
    }
}