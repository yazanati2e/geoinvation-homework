using Genovationai.TaskManagement.Api.Dtos;
using Genovationai.TaskManagement.Core.Abstraction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Genovationai.TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            return Ok(new GetTaskDto(record));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var records = await _tasksService.GetAllAsync();
            if (records is null || !records.Any())
            {
                return NotFound();
            }

            var tasks = new List<GetTaskDto>();

            foreach(var task in records)
            {
                tasks.Add(new GetTaskDto(task));
            }
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTaskDto taskDto)
        {
            var taskRcord = new Core.Entities.Task() { AssignedToId = taskDto.AssignedToId, Description = taskDto.Description, Title = taskDto.Title, Status = taskDto.Status };

            if(taskDto.Id.HasValue)
            {
                taskRcord.Id = taskDto.Id.Value;
                var updatedRecord = await _tasksService.UpdateTaskAsync(taskRcord);
                if (updatedRecord is null)
                {
                    return NotFound();
                }
                return Ok(updatedRecord);
            }
            var addedTaskRecord = await _tasksService.CreateAsync(taskRcord);
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
        [Authorize(Roles = "Admin")]
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
