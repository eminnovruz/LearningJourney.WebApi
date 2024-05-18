using Application.Repositories.Repository;
using Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories.Repository;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }

    DbSet<T> Table => _context.Set<T>();

    public T Get(string id)
    {
        var entity = Table.FirstOrDefault(x => x.Id == id);

        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        return entity;
    }

    public  IEnumerable<T> GetAll(bool tracking = true)
    {
        if(tracking)
        {
            return Table.ToList();
        }

        return Table.AsNoTracking().ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync() // extra method for background services
    {
        return await Table.ToListAsync();
    }

    public async Task<T> GetAsync(string id)
    {
        var entity = await Table.FirstOrDefaultAsync(x => x.Id == id);
        
        if(entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        return entity;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await Table.FirstOrDefaultAsync(expression);

        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        return entity;
    }

    public IEnumerable<T> GetWhere(Expression<Func<T, bool>> expression)
    {
        return Table.Where(expression);
    }
}
