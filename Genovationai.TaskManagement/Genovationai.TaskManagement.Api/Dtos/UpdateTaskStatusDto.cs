namespace Genovationai.TaskManagement.Api.Dtos;

public class UpdateTaskStatusDto
{
    public int TaskId { get; set; }
    public Core.Entities.TaskStatus NewStatus { get; set; }
}

