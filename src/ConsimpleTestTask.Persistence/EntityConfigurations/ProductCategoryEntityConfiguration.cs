using ConsimpleTestTask.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsimpleTestTask.Persistence.EntityConfigurations;

public class ProductCategoryEntityConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("product_categories");

        builder.HasKey(property => property.Id);

        builder.Property(property => property.Id)
            .HasColumnName("id");

        builder.Property(property => property.Name)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("name")
            .IsRequired();

        builder.HasMany(property => property.Products)
            .WithOne(property => property.ProductCategory)
            .HasForeignKey(property => property.CategoryId)
            .IsRequired();
    }
}