using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Cryptography.X509Certificates;
using TaskList.Data;
using TaskList.DTOs;
using TaskList.Models;

namespace TaskList.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public TaskItem criarTask(Create_Task dto)
        {
            var task = new TaskItem(dto.Titulo, dto.Descricao);

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return task;
        }

        public bool temTask()
        {
            return _context.Tasks.Any();
        }

        public List<TaskItem> ListarTasks()
        {

            var tasks = _context.Tasks.ToList();

            return tasks;
        }

        public TaskItem atualizarTask(int id, Create_Task dto)
        {
            var task = _context.Tasks.Find(id);

            if(task == null)
            {
                return null;
            }

            task.Atualizar(dto.Titulo, dto.Descricao);

            _context.SaveChanges();

            return task;
        }

        public TaskItem deletarTask(int id)
        {
            var task = _context.Tasks.Find(id);

            if( task == null )
            {
                return null;
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return task;
        }
   
    }
}
