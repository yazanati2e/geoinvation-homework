using System.ComponentModel.DataAnnotations;

namespace Genovationai.TaskManagement.Api.Dtos;

public class UpdateTaskStatusDto
{
    [Required]
    public int TaskId { get; set; }

    [Required]
    public Core.Entities.TaskStatus NewStatus { get; set; }
}

