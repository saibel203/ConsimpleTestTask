using ConsimpleTestTask.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsimpleTestTask.Persistence.EntityConfigurations;

public class PurchaseItemEntityConfiguration : IEntityTypeConfiguration<PurchaseItem>
{
    public void Configure(EntityTypeBuilder<PurchaseItem> builder)
    {
        builder.ToTable("purchase_items");

        builder.HasKey(property => property.Id);

        builder.Property(property => property.Id)
            .HasColumnName("id");

        builder.Property(property => property.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.Ignore(property => property.TotalPrice);
    }
}