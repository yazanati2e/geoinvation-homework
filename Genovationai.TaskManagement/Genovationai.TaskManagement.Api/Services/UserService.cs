using Genovationai.TaskManagement.Api.Dtos;
using Genovationai.TaskManagement.Core.Abstraction;
using Genovationai.TaskManagement.Core.Abstraction.Services;
using Genovationai.TaskManagement.Core.Entities;

namespace Genovationai.TaskManagement.Api.Services;

public class UserService : IUsersService
{
    public IRepository<TeamMember> _userRepository;

    public UserService(IRepository<TeamMember> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<TeamMember> CreateAsync(TeamMember user)
    {

        await _userRepository.AddAsync(user);
        await _userRepository.Save();

        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingUser = await _userRepository.GetByIdAsync(id);
        if (existingUser is null)
        {
            return false;
        }
        await _userRepository.DeleteAsync(existingUser.Id);
        await _userRepository.Save();

        return true;
    }

    public async Task<IEnumerable<TeamMember>?> GetAllAsync()
    {
        var records = await _userRepository.GetAllAsync();

        if (records is null || !records.Any())
        {
            return null;
        }

        return records;
    }

    public async Task<TeamMember?> GetByIdAsync(int id)
    {
        var record = await _userRepository.GetByIdAsync(id);

        if (record is null)
        {
            return null ;
        }

        return record;
    }

    public async Task<TeamMember?> UpdateAsync(TeamMember user)
    {
        var existingUser = await _userRepository.GetByIdAsync(user.Id);
        if (existingUser is null)
        {
            return null;
        }
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        _userRepository.Update(existingUser);
        await _userRepository.Save();

        return existingUser;
    }
}

