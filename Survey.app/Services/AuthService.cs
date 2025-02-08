


using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Survey.App.Authentication;

namespace Survey.app.Services
{
    public class AuthService(UserManager<ApplicationUser> userManager , IConfiguration Config , IJwtProvider jwtprovider) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager= userManager;
        private readonly IConfiguration _config = Config;
        private readonly IJwtProvider _jwtProvider = jwtprovider;
        public async Task<AuthResponse> GetTokenAsync(string Email, CancellationToken cancellationToken, string password)
        {
            //check email
            var user = await _userManager.FindByEmailAsync(Email);
            if (user is null)
            {
                return null;
            }
            
            //check password 
            var validpassword = await _userManager.CheckPasswordAsync(user, password);

            if(!validpassword)
            {
                return null;
            }

            var (token, expiresIn) = _jwtProvider.GenerateToken(user);

            return new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, token, expiresIn);
        }


    }
}
