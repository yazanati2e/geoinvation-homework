
using Genovationai.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genovationai.TaskManagement.Infrastructure.Database.Config;

internal class TeamMemberConfiguration : BaseEntityConfig, IEntityTypeConfiguration<TeamMember>
{
    public void Configure(EntityTypeBuilder<TeamMember> builder)
    {
        ConfigureBaseEntity(builder);

        builder.Property(tm => tm.FirstName)
               .IsRequired();
        builder.Property(tm => tm.LastName)
               .IsRequired();

        builder.HasMany(tm => tm.Tasks)
               .WithOne(t => t.AssignedTo)
               .HasForeignKey(tm => tm.AssignedToId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}

