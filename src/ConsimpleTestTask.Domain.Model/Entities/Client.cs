using ConsimpleTestTask.Domain.Model.Entities.Base;

namespace ConsimpleTestTask.Domain.Model.Entities;

public class Client : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string FatherName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime RegisterDate { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}