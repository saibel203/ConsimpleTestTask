namespace ConsimpleTestTask.Application.Dto.Dtos;

/// <summary>
/// Client data
/// </summary>
public class ClientDto
{
    /// <summary>
    /// Client id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Client full name
    /// </summary>
    public required string FullName { get; set; }
}