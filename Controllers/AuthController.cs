using JWTToken_1.Model;
using JWTToken_1.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTToken_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]

        public async Task<IActionResult> Register(User user)
        {
            var result = await _authService.Register(user);
            if (result == "User registered successfully")
            {
                return Ok(new { message = result });
            }
            else
            {
                return BadRequest(new { message = result });
            }
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.Login(loginDto);
            if (result != null)
                return Ok(result);
            return BadRequest("Invalid username or password");
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            var result = await _authService.RefreshToken(refreshToken);

            if (result == null)
                return Unauthorized("Invalid refresh token");

            return Ok(result);
        }
    }
}
