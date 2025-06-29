using IdentityCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Migrations;

namespace IdentityInfra.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly IdentityDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(IdentityDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
