using Application.Repositories.Repository;
using Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Repository;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }

    DbSet<T> Table => _context.Set<T>();

    public bool Add(T Entity)
    {
        var entry = Table.Add(Entity);
        return entry.State == EntityState.Added;
    }

    public async Task<bool> AddAsync(T Entity)
    {
        var entry = await Table.AddAsync(Entity);
        return entry.State == EntityState.Added;
    }

    public bool Update(T Entity)
    {
        var entry = Table.Update(Entity);
        return entry.State == EntityState.Modified;
    }

    public async Task<bool> UpdateAsync(string id)
    {
        var entity = await Table.FirstOrDefaultAsync(x => x.Id == id);

        if(entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var entry = Table.Update(entity);
        return entry.State == EntityState.Modified;
    }
}
