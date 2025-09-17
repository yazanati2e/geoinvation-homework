namespace Genovationai.TaskManagement.Api.Dtos;

public class TaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? AssignedToId { get; set; }
}

