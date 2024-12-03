namespace ConsimpleTestTask.Domain.Model.ResultItems.ErrorsDocumentations;

public static class ClientErrors
{
    public static readonly DomainError BirthDateFormatingError =
        new("ClientErrors.BirthDateFormatingError",
            "Error trying to format date. You may have entered an incorrect date format");
    
    public static readonly DomainError NonExistingUserError =
        new("ClientErrors.NonExistingUserError",
            "User with the specified Id not found");
}