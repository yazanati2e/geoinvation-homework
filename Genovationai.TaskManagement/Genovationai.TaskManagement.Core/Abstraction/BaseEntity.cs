

namespace Genovationai.TaskManagement.Core.Abstraction;

/// <summary>
/// Base of all entities
/// </summary>
public abstract class BaseEntity : IBaseEntity
{

    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who created the entity.
    /// </summary>
    public int CreatedBy { get; set; }


    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    /// <summary>
    /// Gets or sets the identifier of the user who last updated the entity.
    /// </summary>
    public int? UpdatedBy { get; set; }


    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}

