using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskList.DTOs;
using TaskList.Services;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;


        public AuthController(AuthService auth)
        {
            _authService = auth;
        }
         
        [HttpPost("signin")]
        public async Task<IActionResult> Login(           
            [FromBody] login_Usuario dto,
            [FromServices] IConfiguration config)
        {
            var token = await _authService.Login(dto, config);

            if(token == null)
            {
                return Unauthorized("Email ou senha inválidos");
            }

            return Ok(new { token });
        }
    }
}
