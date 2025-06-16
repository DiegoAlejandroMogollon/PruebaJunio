using InventoryAPI.Auth;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Usuario de prueba en memoria
        if (request.Username == "admin" && request.Password == "1234")
        {
            var token = _jwtService.GenerateToken(request.Username);
            return Ok(new { token });
        }

        return Unauthorized("Invalid credentials");
    }
}
