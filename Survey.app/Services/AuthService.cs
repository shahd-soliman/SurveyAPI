


using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Survey.app.Services
{
    public class AuthService(UserManager<ApplicationUser> userManager , IConfiguration Config) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager= userManager;
        private readonly IConfiguration _config = Config;
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

          string Token = GenerateJwtToken(user.UserName);
            return new AuthResponse( user.FirstName, user.LastName, user.Email, Token, Convert.ToInt32(_config.GetSection("JWT")["DurationInMinutes"]));
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _config.GetSection("JWT");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
