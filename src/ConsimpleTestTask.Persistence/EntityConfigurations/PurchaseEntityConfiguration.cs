using ConsimpleTestTask.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsimpleTestTask.Persistence.EntityConfigurations;

public class PurchaseEntityConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("purchases");

        builder.HasKey(property => property.Id);

        builder.Property(property => property.Id)
            .HasColumnName("id");
        
        builder.Property(property => property.Date)
            .HasDefaultValueSql("getutcdate()")
            .HasColumnName("date")
            .IsRequired();

        builder.Ignore(property => property.TotalAmount);
        
        builder.HasMany(property => property.PurchaseItems)
            .WithOne(property => property.Purchase)
            .HasForeignKey(property => property.PurchaseId)
            .IsRequired();
    }
}