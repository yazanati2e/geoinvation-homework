namespace Genovationai.TaskManagement.Api.Dtos;

public class GetTaskDto
{

    public GetTaskDto(Core.Entities.Task taskRecord)
    {
        Id = taskRecord.Id;
        Title = taskRecord.Title;
        Description = taskRecord.Description;
    }
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }
}

