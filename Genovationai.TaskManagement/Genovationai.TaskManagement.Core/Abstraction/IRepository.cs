

using System.Linq.Expressions;

namespace Genovationai.TaskManagement.Core.Abstraction;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(int id, string? includes = null);
    Task<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool>? filterCondition = null);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    Task DeleteAsync(int id);
    Task Save();
}

