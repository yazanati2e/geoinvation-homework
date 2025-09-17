using Genovationai.TaskManagement.Core.Abstraction.Services;
using Genovationai.TaskManagement.Core.Entities;
using Genovationai.TaskManagement.Infrastructure.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Task = Genovationai.TaskManagement.Core.Entities.Task;

namespace Genovationai.TaskManagement.Infrastructure.Database;

/// <summary>
/// Hides the database context for the application, integrating with ASP.NET Core Identity.
/// </summary>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
    public DbSet<Task> Tasks => Set<Task>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}

