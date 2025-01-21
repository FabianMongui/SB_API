using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SB.Application.Services;
using SB.Domain.Entities;

namespace SB.API.Controllers
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
        public IActionResult Login([FromBody] UserEntity user)
        {
            if (user.Username == "usuario" && user.Password == "contrasenia123")
            {
                var token = _jwtService.GenerateToken(user.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
