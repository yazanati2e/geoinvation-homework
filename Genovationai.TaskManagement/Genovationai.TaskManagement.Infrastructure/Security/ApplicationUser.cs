using Microsoft.AspNetCore.Identity;

namespace Genovationai.TaskManagement.Infrastructure.Security;

/// <summary>
/// Represents an application user in the identity system.
/// </summary>
public class ApplicationUser :IdentityUser<int>
{
}

