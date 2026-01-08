using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    return Ok(_context.Tasks.ToList());
        //}
    }
}
