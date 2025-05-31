using HRM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Persistence.Configurations;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.EmployeeCode)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(e => e.EmployeeCode).IsUnique(); // Index

        builder.Property(e => e.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(e => e.FirstName); // Index

        builder.Property(e => e.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(e => e.LastName); // Index

        builder.Property(e => e.FatherName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.NationalCode)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(e => e.NationalCode).IsUnique(); // Index

        builder.Property(e => e.Gender)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.BirthPlace)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.BirthDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(e => e.MaritalStatus)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.MarriageDate)
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.HousingStatus)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.MobileNumber)
            .HasMaxLength(11)
            .IsRequired();

        builder.HasIndex(e => e.MobileNumber).IsUnique(); //Index

        builder.Property(e => e.Address)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.ZipCode)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.ProfileImage)
            .HasColumnType("varbinary(max)")
            .IsRequired(false);
    }
}
