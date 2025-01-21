namespace Survey.app.Contracts.Users
{
    public record AuthResponse
    (
        int id,
        string FirstName,
        string LastName,
        string? Email,
        string Token,
        int ExpiredIn
        );

}
