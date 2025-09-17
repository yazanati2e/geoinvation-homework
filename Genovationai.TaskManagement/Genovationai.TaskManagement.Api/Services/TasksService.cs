
using Genovationai.TaskManagement.Core.Abstraction;
using Genovationai.TaskManagement.Core.Abstraction.Services;

namespace Genovationai.TaskManagement.Api.Services;
public class TasksService : ITasksService
{
    private readonly IRepository<Core.Entities.Task> _tasksRepository;

    public TasksService(IRepository<Core.Entities.Task> tasksRepository)
    {
        _tasksRepository = tasksRepository;
    }
    public async Task<Core.Entities.Task> CreateAsync(Core.Entities.Task newTask)
    {
        await _tasksRepository.AddAsync(newTask);
        await _tasksRepository.Save();

        return newTask;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingTask = await _tasksRepository.GetByIdAsync(id);
        if (existingTask is null)
        {
            return false;
        }
        await _tasksRepository.DeleteAsync(existingTask.Id);
        await _tasksRepository.Save();

        return true;
    }

    public async Task<Core.Entities.Task?> GetByIdAsync(int id)
    {
        var record = await _tasksRepository.GetByIdAsync(id);

        if (record is null)
        {
            return null;
        }

        return record;
    }

    public async Task<Core.Entities.Task?> UpdateStatusAsync(int id, Core.Entities.TaskStatus newStatus)
    {
        var record = await _tasksRepository.GetByIdAsync(id);

        if (record is null)
        {
            return null;
        }

        record.Status = newStatus;
        _tasksRepository.Update(record);
        await _tasksRepository.Save();

        return record;
    }

    public async Task<Core.Entities.Task?> UpdateTaskAsync(Core.Entities.Task TaskUpdate)
    {
        var record = await _tasksRepository.GetByIdAsync(TaskUpdate.Id);

        if (record is null)
        {
            return null;
        }

        record.Title = TaskUpdate.Title;
        record.Description = TaskUpdate.Description;
        record.AssignedToId = TaskUpdate.AssignedToId;
        record.Status = TaskUpdate.Status;

        _tasksRepository.Update(record);
        await _tasksRepository.Save();

        return record;
    }
}

