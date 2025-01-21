using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SB.API.Controllers
{
    public class AuthController : Controller
    {
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly JwtService _jwtService;

            public AuthController(JwtService jwtService)
            {
                _jwtService = jwtService;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] User user)
            {
                // Validar usuario (ejemplo sencillo)
                if (user.Username == "admin" && user.Password == "password")
                {
                    var token = _jwtService.GenerateToken(user.Username);
                    return Ok(new { Token = token });
                }

                return Unauthorized();
            }
        }
    }
}
