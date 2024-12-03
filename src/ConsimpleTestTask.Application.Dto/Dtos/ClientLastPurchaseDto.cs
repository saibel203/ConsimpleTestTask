namespace ConsimpleTestTask.Application.Dto.Dtos;

/// <summary>
/// Client data
/// </summary>
public class ClientLastPurchaseDto
{
    /// <summary>
    /// Client id
    /// </summary>
    public int ClientId { get; set; }
    
    /// <summary>
    /// Client full name
    /// </summary>
    public required string FullName { get; set; }
    
    /// <summary>
    /// Date of last purchase
    /// </summary>
    public required string LastPurchaseDate { get; set; }
}