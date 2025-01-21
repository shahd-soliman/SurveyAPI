


namespace Survey.app.Services
{
    public class AuthService(UserManager<ApplicationUser> userManager) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager= userManager;  
        public async Task<AuthResponse> GetTokenAsync(string Name, string Email, CancellationToken cancellationToken, string password)
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

            //generate gwt token
            //return new AuthResponse
            return;
        }
    }
}
