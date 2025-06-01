using HRM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Persistence.Configurations;

public class DependentConfig : IEntityTypeConfiguration<Dependent>
{
    public void Configure(EntityTypeBuilder<Dependent> builder)
    {
        builder.ToTable("Dependents");

        builder.HasKey(d => d.Id);

        builder.HasOne(d => d.Employee)
            .WithMany(e => e.Dependents)
            .HasForeignKey(d => d.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(d => d.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(d => d.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(d => d.Relation)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(d => d.Gender)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.NationalCode)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(e => e.NationalCode).IsUnique(); // Index

        builder.Property(d => d.BirthDate)
            .HasColumnType("date")
            .IsRequired();
    }
}
