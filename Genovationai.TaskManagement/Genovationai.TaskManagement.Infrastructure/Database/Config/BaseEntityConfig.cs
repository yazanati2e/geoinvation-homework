

using Genovationai.TaskManagement.Core.Abstraction;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genovationai.TaskManagement.Infrastructure.Database.Config;

/// <summary>
/// Common configurator of all entities.
/// </summary>
internal class BaseEntityConfig
{
    /// <summary>
    /// Configures all entities that inherit from BaseEntity
    /// </summary>
    public void ConfigureBaseEntity<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
    {
        builder.HasKey(ent => ent.Id);

        builder.Property(ent => ent.CreatedBy)
               .IsRequired();
        builder.Property(ent => ent.CreatedAt)
            .IsRequired();

        builder.Property(ent => ent.UpdatedBy)
            .IsRequired(false);
        builder.Property(ent => ent.UpdatedAt)
            .IsRequired(false);
    }
}

