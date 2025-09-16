using Genovationai.TaskManagement.Core.Abstraction;

namespace Genovationai.TaskManagement.Core.Entities;

/// <summary>
/// User of the application (both administrators and regular users)
/// </summary>
public class TeamMember : BaseEntity
{
    /// <summary>
    /// Gets or sets the first name of the team member / user.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the last name of the team member / user.
    /// </summary>
    public string LastName { get; set; } = null!;

    public List<Task> Tasks { get; set; } = new();
}

