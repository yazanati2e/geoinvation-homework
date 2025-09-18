using System.ComponentModel.DataAnnotations;

namespace Genovationai.TaskManagement.Api.Dtos;

public class GetTaskDto
{

    public GetTaskDto(Core.Entities.Task taskRecord)
    {
        Id = taskRecord.Id;
        Title = taskRecord.Title;
        Status = taskRecord.Status;
        Description = taskRecord.Description;

        if (taskRecord.AssignedTo is not null)
        {
            AssignedToId = taskRecord.AssignedTo.Id;
            AssignedToFirstName = taskRecord.AssignedTo.FirstName;
            AssignedToLastName = taskRecord.AssignedTo.LastName;
        }
    }
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public Core.Entities.TaskStatus Status { get; set; }

    public int AssignedToId { get; set; }

    public string AssignedToFirstName { get; set; } = string.Empty;

    public string AssignedToLastName { get; set; } = string.Empty;

}

