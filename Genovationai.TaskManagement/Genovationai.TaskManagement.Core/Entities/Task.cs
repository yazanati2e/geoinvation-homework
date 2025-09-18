

using Genovationai.TaskManagement.Core.Abstraction;

namespace Genovationai.TaskManagement.Core.Entities;

/// <summary>
/// Represents a task that can be assigned to a team member.
/// </summary>
public class Task : BaseEntity
{
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? AssignedToId { get; set; }

    public TaskStatus Status { get; set; } = TaskStatus.NotStarted;

    public TeamMember? AssignedTo { get; set; }
}

public enum TaskStatus : int
{
    NotStarted = 1,
    InProgress = 2,
    Completed = 3,
    OnHold = 4,
    Cancelled = 5
}

