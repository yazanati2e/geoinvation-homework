using Genovationai.TaskManagement.Api.Dtos;
using Genovationai.TaskManagement.Core.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Genovationai.TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var record = await _tasksService.GetByIdAsync(id);
            if (record is null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Core.Entities.Task taskDto)
        {
            var addedTaskRecord = await _tasksService.CreateAsync(taskDto);
            return CreatedAtAction(nameof(Get), new { id = addedTaskRecord.Id }, addedTaskRecord);
        }
        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> PatchStatus(int id, [FromBody] UpdateTaskStatusDto updateStatusDto)
        {
            var updatedRecord = await _tasksService.UpdateStatusAsync(id, updateStatusDto.NewStatus);
            if (updatedRecord is null)
            {
                return NotFound();
            }

            return Ok(updatedRecord);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tasksService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
