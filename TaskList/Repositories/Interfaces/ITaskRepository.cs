namespace TaskList.Repositories.Interfaces;
using TaskList.Models;
using TaskList.DTOs;


public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> CreateAsync(Create_Task dto);
    Task<TaskItem?> UpdateAsync(int id, Create_Task dto);
    Task<TaskItem?> UpdateConcluirAsync(int id);
    Task<TaskItem?> DeleteAsync(int id);

}
