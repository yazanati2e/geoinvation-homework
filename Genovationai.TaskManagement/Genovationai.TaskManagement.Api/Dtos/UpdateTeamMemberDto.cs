using System.ComponentModel.DataAnnotations;

namespace Genovationai.TaskManagement.Api.Dtos;

public class UpdateTeamMemberDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
}

