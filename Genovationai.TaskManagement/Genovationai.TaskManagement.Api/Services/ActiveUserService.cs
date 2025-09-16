

using Genovationai.TaskManagement.Core.Abstraction.Services;

namespace Genovationai.TaskManagement.Api.Services;
public class ActiveUserService : IActiveUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ActiveUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public int GetActiveUserId()
    {
        string userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value ?? "0";

        return int.Parse(userIdString);
    }

    public List<string> GetActiveUserRoles()
    {
        return _httpContextAccessor.HttpContext?.User?.FindAll("role")?.Select(r => r.Value).ToList() ?? new List<string>();
    }
}

