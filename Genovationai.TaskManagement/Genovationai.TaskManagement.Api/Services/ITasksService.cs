using Genovationai.TaskManagement.Core.Entities;

namespace Genovationai.TaskManagement.Api.Services
{
    public interface ITasksService
    {
        public Task<Core.Entities.Task?> GetByIdAsync(int id);

        public Task<IEnumerable<TeamMember>?> GetAllAsync();

        public Task<Core.Entities.Task> CreateAsync(Core.Entities.Task user);

        public Task<TeamMember?> UpdateAsync(TeamMember user);

        public Task<bool> DeleteAsync(int id);
    }
}
