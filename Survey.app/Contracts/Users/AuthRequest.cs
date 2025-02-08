namespace Survey.app.Contracts.Users
{
    public record AuthRequest(
        string Email,
        string Password)
   ;
}
