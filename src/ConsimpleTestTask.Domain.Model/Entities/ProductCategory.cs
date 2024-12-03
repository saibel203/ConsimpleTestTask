using ConsimpleTestTask.Domain.Model.Entities.Base;

namespace ConsimpleTestTask.Domain.Model.Entities;

public class ProductCategory : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}