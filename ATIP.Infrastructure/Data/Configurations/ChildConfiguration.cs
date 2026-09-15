using ATIP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATIP.Infrastructure.Data.Configurations;

public class ChildConfiguration : IEntityTypeConfiguration<Child>
{
    public void Configure(EntityTypeBuilder<Child> builder)
    {
        builder.ToTable("Children");

        builder.HasKey(child => child.ChildId);

        builder.Property(child => child.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(child => child.MiddleName)
            .HasMaxLength(100);

        builder.Property(child => child.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(child => child.Gender)
            .HasMaxLength(30);

        builder.Property(child => child.Phone)
            .HasMaxLength(30);

        builder.Property(child => child.Address)
            .HasMaxLength(300);

        builder.Property(child => child.State)
            .HasMaxLength(100);

        builder.Property(child => child.Lga)
            .HasMaxLength(100);

        builder.Property(child => child.SchoolName)
            .HasMaxLength(200);

        builder.Property(child => child.ClassLevel)
            .HasMaxLength(100);

        builder.Property(child => child.Status)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(child => child.DiscoveryLocation)
            .HasMaxLength(200);

        builder.Property(child => child.DiscoveryNotes)
            .HasMaxLength(2000);

        builder.Property(child => child.CreatedAt)
            .IsRequired();

        builder.Property(child => child.UpdatedAt)
            .IsRequired();

        builder.HasIndex(child => child.LastName);

        builder.HasIndex(child => child.Status);

        builder.HasIndex(child => child.DiscoveryDate);
    }
}