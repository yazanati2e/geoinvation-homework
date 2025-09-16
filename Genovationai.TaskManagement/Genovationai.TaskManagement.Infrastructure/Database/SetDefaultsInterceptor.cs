
using Genovationai.TaskManagement.Core.Abstraction;
using Genovationai.TaskManagement.Core.Abstraction.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Genovationai.TaskManagement.Infrastructure.Database;
internal class SetDefaultsInterceptor : SaveChangesInterceptor
{
    private readonly IActiveUserService _activeUserService;
    public SetDefaultsInterceptor(IActiveUserService activeUserService)
    {
        _activeUserService = activeUserService;
    }
    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
        {
            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        foreach (var entry in eventData.Context.ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State is EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.CreatedBy = _activeUserService.GetActiveUserId();
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedBy = _activeUserService.GetActiveUserId();
            }

        }

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }
}

