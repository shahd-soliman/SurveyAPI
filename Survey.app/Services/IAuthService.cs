
namespace Survey.app.Services
{
    public interface IAuthService
    {
       Task <AuthResponse> GetTokenAsync(string Name ,string Email ,CancellationToken cancellationToken, string password);
    }
}
