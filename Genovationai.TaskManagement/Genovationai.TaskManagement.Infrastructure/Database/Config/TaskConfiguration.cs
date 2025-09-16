
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genovationai.TaskManagement.Infrastructure.Database.Config;

internal class TaskConfiguration : BaseEntityConfig, IEntityTypeConfiguration<Core.Entities.Task>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Task> builder)
    {
        ConfigureBaseEntity(builder);

        builder.Property(t => t.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(t => t.Description)
                .IsRequired(false)
                .HasMaxLength(10_000);

        builder.HasOne(t => t.AssignedTo)
                .WithMany(tm => tm.Tasks);
    }
}

