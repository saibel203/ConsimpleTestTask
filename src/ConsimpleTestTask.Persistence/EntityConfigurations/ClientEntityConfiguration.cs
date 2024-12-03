using ConsimpleTestTask.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsimpleTestTask.Persistence.EntityConfigurations;

public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("clients");

        builder.HasKey(property => property.Id);

        builder.Property(property => property.Id)
            .HasColumnName("id");

        builder.Property(property => property.FirstName)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("first_name")
            .IsRequired();
        
        builder.Property(property => property.LastName)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("last_name")
            .IsRequired();
        
        builder.Property(property => property.FatherName)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("father_name")
            .IsRequired();
        
        builder.Property(property => property.BirthDate)
            .HasDefaultValueSql("getutcdate()")
            .HasColumnName("birth_date")
            .IsRequired();
        
        builder.Property(property => property.RegisterDate)
            .HasDefaultValueSql("getutcdate()")
            .HasColumnName("register_date")
            .IsRequired();

        builder.HasMany(property => property.Purchases)
            .WithOne(property => property.Client)
            .HasForeignKey(property => property.ClientId)
            .IsRequired();
    }
}