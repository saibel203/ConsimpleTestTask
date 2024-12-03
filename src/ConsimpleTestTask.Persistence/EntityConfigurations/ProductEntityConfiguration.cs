using ConsimpleTestTask.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsimpleTestTask.Persistence.EntityConfigurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(property => property.Id);

        builder.Property(property => property.Id)
            .HasColumnName("id");

        builder.Property(property => property.Name)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("name")
            .IsRequired();

        builder.Property(property => property.Sku)
            .HasColumnType("nvarchar(50)")
            .HasColumnName("sku")
            .IsRequired();

        builder.Property(property => property.Price)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("price")
            .IsRequired();

        builder.Property(property => property.CategoryId)
            .HasColumnName("category_id");
        
        builder.HasMany(property => property.PurchaseItems)
            .WithOne(property => property.Product)
            .HasForeignKey(property => property.ProductId)
            .IsRequired();
    }
}