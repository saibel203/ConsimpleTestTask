using ConsimpleTestTask.Domain.Model.Entities.Base;

namespace ConsimpleTestTask.Domain.Model.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }

    public int CategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; } = null!;

    public required string Sku { get; set; } // Stock Keeping Unit
    public decimal Price { get; set; }

    public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
}