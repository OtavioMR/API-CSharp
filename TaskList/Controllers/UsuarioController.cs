using Microsoft.AspNetCore.Mvc;
using TaskList.Services;
using TaskList.DTOs;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)    
        {
            _service = service;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Create([FromBody] Create_Usuario dto)
        {
            var usuario = await _service.CreateUsuario(dto);

            if(usuario == null)
            {
                return BadRequest("Preencha todos os campos!");
            }

            var usuarioResponse = new
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };

            return Ok(usuarioResponse);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _service.GetAllUsuarios();

            if (!usuarios.Any()) return NotFound("Nenhum usuário cadastrado");

            var usuariosResponse = usuarios.Select(u => new
            {
                u.Id,
                u.Nome,
                u.Email
            });

            return Ok(usuariosResponse);
        }
    }

}
