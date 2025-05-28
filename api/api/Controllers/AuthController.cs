using api.Helper;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AuthController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel login)
        {
            // Replace with actual user validation
            if (login.Username == "admin" && login.Password == "password")
            {
                var token = TokenHelper.GenerateJwtToken(login.Username, _jwtSettings);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
