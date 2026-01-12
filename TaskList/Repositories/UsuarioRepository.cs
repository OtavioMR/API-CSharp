using Microsoft.EntityFrameworkCore;
using TaskList.Data;
using TaskList.Models;
using TaskList.Repositories.Interfaces;

namespace TaskList.Repositories
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateAsync(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync() =>
            await _context.Usuarios.ToListAsync();

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }

        public async Task<Usuario?> UpdateAsync(int id, Usuario entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return null;
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public Task<Usuario?> UpdateConcluirAsync(int id)
        {
            throw new NotImplementedException();
        }


    }
}
