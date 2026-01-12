using TaskList.Data;
using TaskList.Repositories.Interfaces;
using TaskList.Models;
using TaskList.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TaskList.Repositories
{
    public class TaskRepository : IRepository<TaskItem>
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync() =>
            await _context.Tasks.ToListAsync();

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            var task =  await _context.Tasks.FindAsync(id);

            if(task == null)
            {
                return null;
            }

            return task;
        }

        public async Task<TaskItem> CreateAsync(TaskItem entity)
        {
            _context.Tasks.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TaskItem?> UpdateAsync(int id, TaskItem entity)
        {

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return null;
            }

           task.Atualizar(entity.Titulo, entity.Descricao);

            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskItem?> UpdateConcluirAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if(task == null)
            {
                return null;
            }

            task.MarcarComoConcluida();

            await _context.SaveChangesAsync();

            return task;
        }


        public async Task<TaskItem?> DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
                return null;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }


    }
}
