using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Cryptography.X509Certificates;
using TaskList.Data;
using TaskList.DTOs;
using TaskList.Models;
using TaskList.Repositories.Interfaces;

namespace TaskList.Services
{
    public class TaskService
    {
        private readonly IRepository<TaskItem> _repo;

        public TaskService(IRepository<TaskItem> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks() => await _repo.GetAllAsync();
        public async Task<TaskItem?> GetTaskById(int id) => await _repo.GetByIdAsync(id);
        public async Task<TaskItem?> CreateTask(Create_Task dto)
        {
            var task = new TaskItem(dto.Titulo, dto.Descricao);

            return await _repo.CreateAsync(task);
        }
        public async Task<TaskItem?> UpdateTask(int id, Create_Task dto)
        {
            var task = new TaskItem(dto.Titulo, dto.Descricao);

            return await _repo.UpdateAsync(id, task);
        }
        public async Task<TaskItem?> UpdateConcluirTask(int id) => await _repo.UpdateConcluirAsync(id);
        public async Task<TaskItem?> DeleteTask(int id) => await _repo.DeleteAsync(id);

    }
}
