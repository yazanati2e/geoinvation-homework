

namespace Genovationai.TaskManagement.Core.Abstraction.Services;

public interface ITasksService
{
    public Task<Core.Entities.Task?> GetByIdAsync(int id);

    public Task<IEnumerable<Core.Entities.Task>?> GetAllAsync();

    public Task<Core.Entities.Task> CreateAsync(Core.Entities.Task newTask);

    public Task<Core.Entities.Task?> UpdateTaskAsync(Core.Entities.Task TaskUpdate);


    public Task<Core.Entities.Task?> UpdateStatusAsync(int id, Core.Entities.TaskStatus newStatus);

    public Task<bool> DeleteAsync(int id);
}

