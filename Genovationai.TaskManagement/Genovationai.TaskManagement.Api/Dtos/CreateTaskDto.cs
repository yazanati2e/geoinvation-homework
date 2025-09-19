using System.ComponentModel.DataAnnotations;

namespace Genovationai.TaskManagement.Api.Dtos;

public class CreateTaskDto
{
    public int? Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? AssignedToId { get; set; }

    [Required]
    public Core.Entities.TaskStatus Status { get; set; } = Core.Entities.TaskStatus.NotStarted;
}

