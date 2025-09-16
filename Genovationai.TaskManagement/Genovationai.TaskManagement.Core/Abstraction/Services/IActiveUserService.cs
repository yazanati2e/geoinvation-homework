

namespace Genovationai.TaskManagement.Core.Abstraction.Services;

public interface IActiveUserService
{
    /// <summary>
    /// Gets the ID of the active user.
    /// </summary>
    /// <returns>ID of the active user.</returns>
    int GetActiveUserId();

    /// <summary>
    /// Get roles of the active user.
    /// </summary>
    /// <returns>Roles of the active user.</returns>
    List<string> GetActiveUserRoles();
}

