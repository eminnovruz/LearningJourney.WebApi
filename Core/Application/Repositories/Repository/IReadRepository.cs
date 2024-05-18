using Domain.Models.Common;
using System.Linq.Expressions;

namespace Application.Repositories.Repository;

public interface IReadRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll(bool tracking = true);

    Task<IEnumerable<T>> GetAllAsync(); // Extra method for background services

    IEnumerable<T> GetWhere(Expression<Func<T, bool>> expression);

    Task<T> GetAsync(string id);
    Task<T> GetAsync(Expression<Func<T, bool>> expression);

    // Extra methods
    T Get(string id);
}
