using Genovationai.TaskManagement.Core.Entities;

namespace Genovationai.TaskManagement.Api.Dtos;

public class TeamMemberDto
{

    public TeamMemberDto()
    {
    }

    public TeamMemberDto(TeamMember user)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
    }
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}

