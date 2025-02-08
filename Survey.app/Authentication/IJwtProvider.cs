namespace Survey.App.Authentication;

public interface IJwtProvider
{
    (string token, int expiresIn) GenerateToken(ApplicationUser user);
}