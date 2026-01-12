using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using TaskList.Data;
using TaskList.DTOs;
using TaskList.Models;
using TaskList.Services;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _service;

        public TaskController(TaskService service)
        {
            _service = service;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Create([FromBody] Create_Task dto)
        {
           var task = await _service.CreateTask(dto);

            if (task == null)
            {
                return BadRequest("Preencha todos os campos!");
            }

            return Ok(task);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _service.GetAllTasks();

            if (!tasks.Any()) return NotFound("Nenhuma task cadastrada");

            return Ok(tasks);
        }

        [HttpGet("listar/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _service.GetTaskById(id);
            if (task == null)
            {
                return NotFound("Task não encontrada");
            }
            return Ok(task);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Create_Task dto)
        {
            var task = await _service.UpdateTask(id, dto);

            if(task == null)
            {
                return NotFound("Task não encontrada");
            }

            return Ok(task);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _service.DeleteTask(id);
            if (task == null) return NotFound("Task não encontrada");

            return NoContent();
        }

        [HttpPatch("concluir/{id}")]
        public async Task<IActionResult> Patch(int id)
        {
            var task = await _service.GetTaskById(id);

            if (task == null)
            {
                return NotFound("Task não encontrada");
            }

            task = await _service.UpdateConcluirTask(id);

            return Ok(task);

        }

    }
}
