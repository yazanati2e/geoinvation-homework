

using Genovationai.TaskManagement.Core.Entities;

namespace Genovationai.TaskManagement.Core.Abstraction.Services;

public interface IUsersService
{
    public Task<TeamMember?> GetByIdAsync(int id);

    public Task<IEnumerable<TeamMember>?> GetAllAsync();

    public Task<TeamMember> CreateAsync(TeamMember user);

    public Task<TeamMember?> UpdateAsync(TeamMember user);

    public Task<bool> DeleteAsync(int id);
}

