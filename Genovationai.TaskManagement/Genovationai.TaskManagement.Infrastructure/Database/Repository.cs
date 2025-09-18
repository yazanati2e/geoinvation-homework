

using Genovationai.TaskManagement.Core.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Genovationai.TaskManagement.Infrastructure.Database;

public class Repository<TEnitity> : IRepository<TEnitity> where TEnitity : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEnitity> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEnitity>();
    }
    public async Task AddAsync(TEnitity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        TEnitity? record = await _dbSet.FindAsync(id);

        if (record is not null)
        {
            _dbSet.Remove(record);
        }
    }

    public async Task<IEnumerable<TEnitity>> GetAllAsync(Func<TEnitity, bool>? filterCondition = null)
    {
        if (filterCondition is null)
        {
            return await _dbSet.ToListAsync();
        }


        return _dbSet.Where(filterCondition).ToList();
    }

    public async Task<TEnitity?> GetByIdAsync(int id, string? includes = null)
    {
        var query = _dbSet.Where(e => e.Id == id);

        if(!string.IsNullOrEmpty(includes))
        {
            query = query.Include(includes);
        }

        return await query.FirstOrDefaultAsync();
    }

    public void Update(TEnitity entity)
    {
        _dbSet.Update(entity);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}

