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
        public IActionResult Create([FromBody] Create_Task dto)
        {
           var task = _service.criarTask(dto);

            return Ok(task);
        }

        [HttpGet("listar")]
        public IActionResult GetAll()
        {
       
            if(!_service.temTask()) return NotFound("Nenhuma task cadastrada");


            var tasks = _service.ListarTasks();

            return Ok(tasks);
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Put(int id, [FromBody] Create_Task dto)
        {
            var task = _service.atualizarTask(id, dto);

            if(task == null)
            {
                return NotFound("Task não encontrada");
            }

            return Ok(task);
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(int id)
        {
            var task = _service.deletarTask(id);
            if (task == null) return NotFound("Task não encontrada");

            return NoContent(); // 204
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    return Ok(_context.Tasks.ToList());
        //}
    }
}
