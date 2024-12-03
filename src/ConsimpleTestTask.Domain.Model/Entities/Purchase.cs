using ConsimpleTestTask.Domain.Model.Entities.Base;

namespace ConsimpleTestTask.Domain.Model.Entities;

public class Purchase : BaseEntity
{
    public DateTime Date { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    public decimal TotalAmount => PurchaseItems.Sum(item => item.TotalPrice);
}