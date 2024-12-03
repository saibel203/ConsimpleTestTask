namespace ConsimpleTestTask.Application.Dto.Dtos;

public class CategoryPurchaseDto
{
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public int TotalUnitsPurchased { get; set; }
    public required string UserName { get; set; }
}