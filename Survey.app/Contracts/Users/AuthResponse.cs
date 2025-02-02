namespace Survey.app.Contracts.Users
{
    public record AuthResponse
    (
      
        string FirstName,
        string LastName,
        string? Email,
        string Token,
        int ExpiredIn
        );

}
