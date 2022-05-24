using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Tasklist.Api.Models;
using Tasklist.Api.Services;

namespace Tasklist.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        // GET api/tasks
        [HttpGet]
        public IEnumerable<TaskItem> Get()
        {
            return taskService.GetAll();
        }

        // GET api/tasks/1
        [HttpGet("{taskNumber}")]
        public IEnumerable<TaskItem> Get(int taskNumber)
        {
            return taskService.Generate(taskNumber);
        }

        // PUT api/tasks/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TaskItem taskItem)
        {
            taskService.Update(id, taskItem);

            return NoContent();
        }

        public override NoContentResult NoContent()
        {
            return base.NoContent();
        }
    }
}
