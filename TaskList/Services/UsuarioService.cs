using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskList.DTOs;
using TaskList.Models;
using TaskList.Repositories.Interfaces;

namespace TaskList.Services
{
    public class UsuarioService
    {
        private readonly IRepository<Usuario> _repo;
        private readonly PasswordHasher<Usuario> _hasher;

        public UsuarioService(IRepository<Usuario> repo)
        {
            _repo = repo;
            _hasher = new PasswordHasher<Usuario>();
        }

        public async Task<Usuario?> CreateUsuario(Create_Usuario dto)
        {
            var usuario = new Usuario(dto.Nome, dto.Email);

            usuario.Senha = _hasher.HashPassword(usuario, dto.Senha);

            return await _repo.CreateAsync(usuario);
        }


        public async Task<IEnumerable<Usuario>> GetAllUsuarios() => await _repo.GetAllAsync();
        public async Task<Usuario?> GetUsuarioById(int id) => await _repo.GetByIdAsync(id);
        public async Task<Usuario?> UpdateUsuario(int id, Create_Usuario dto)
        {
            var usuario = new Usuario(dto.Nome, dto.Email);
            usuario.Senha = _hasher.HashPassword(usuario, dto.Senha);
            return await _repo.UpdateAsync(id, usuario);
        }

        public async Task<Usuario?> DeleteUsuario(int id) => await _repo.DeleteAsync(id);
    }
}
