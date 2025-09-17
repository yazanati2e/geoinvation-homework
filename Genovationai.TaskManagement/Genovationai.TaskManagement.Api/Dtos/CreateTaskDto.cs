using Genovationai.TaskManagement.Core.Entities;

namespace Genovationai.TaskManagement.Api.Dtos;

public class CreateTaskDto
{
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? AssignedToId { get; set; }

    public Core.Entities.TaskStatus Status { get; set; } = Core.Entities.TaskStatus.NotStarted;
}

