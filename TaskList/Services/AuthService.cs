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
    public class AuthService
    {

        private readonly IRepository<Usuario> _repo;
        private readonly PasswordHasher<Usuario> _hasher;

        public AuthService(IRepository<Usuario> repo)
        {
            _repo = repo;
            _hasher = new PasswordHasher<Usuario>();
        }



        //Autenticação de usuário
        public async Task<string?> Login(login_Usuario dto, IConfiguration config)
        {
            var usuario = (await _repo.GetAllAsync())
                .FirstOrDefault(u => u.Email == dto.email);

            if (usuario == null)
            {
                return null;
            }

            var result = _hasher.VerifyHashedPassword(usuario, usuario.Senha, dto.senha);

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            var jwtSettings = config.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Nome)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(int.Parse(jwtSettings["ExpiresInHours"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }


    }
}
