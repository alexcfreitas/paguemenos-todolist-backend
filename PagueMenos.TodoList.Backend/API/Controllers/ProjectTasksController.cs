using Microsoft.AspNetCore.Mvc;
using PagueMenos.TodoList.Application.Services;
using PagueMenos.TodoList.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PagueMenos.TodoList.API.Controllers
{
    [Route("api/project-tasks")]
    [ApiController]
    public class ProjectTasksController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;

        public ProjectTasksController(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectTask>>> GetProjectTasks()
        {
            var projectTasks = await _projectTaskService.GetAllProjectTasksAsync();
            return Ok(projectTasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTask>> GetProjectTask(int id)
        {
            var projectTask = await _projectTaskService.GetProjectTaskByIdAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }
            return Ok(projectTask);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectTask>> PostProjectTask([FromBody] ProjectTask projectTask)
        {
            var createdTask = await _projectTaskService.AddProjectTaskAsync(projectTask.Title, projectTask.Description);
            return CreatedAtAction(nameof(GetProjectTask), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectTask(int id, [FromBody] ProjectTaskStatusUpdateDto statusUpdateDto)
        {
            await _projectTaskService.UpdateProjectTaskStatusAsync(id, statusUpdateDto.IsCompleted);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectTask(int id)
        {
            await _projectTaskService.DeleteProjectTaskAsync(id);
            return NoContent();
        }
    }

    public class ProjectTaskStatusUpdateDto
    {
        public bool IsCompleted { get; set; }
    }
}
