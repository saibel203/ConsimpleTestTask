namespace ConsimpleTestTask.Domain.Model.ResultItems;

public record DomainError(
    string Code,
    string Description)
{
    public static readonly DomainError None =
        new(string.Empty, string.Empty);
}