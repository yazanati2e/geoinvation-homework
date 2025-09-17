using Genovationai.TaskManagement.Core.Entities;
using System.ComponentModel.DataAnnotations;

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
    [Required]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;
}

