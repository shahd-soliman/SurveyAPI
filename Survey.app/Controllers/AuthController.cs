using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Survey.app.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService= authService; 
        [HttpPost("")]
       public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.GetTokenAsync( request.Email, cancellationToken  , request.Password);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
