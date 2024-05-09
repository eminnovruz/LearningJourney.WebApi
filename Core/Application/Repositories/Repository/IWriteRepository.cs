using Domain.Models.Common;

namespace Application.Repositories.Repository;

public interface IWriteRepository<T> where T : BaseEntity 
{
    // Add methods
    
    Task<bool> AddAsync(T Entity);
    bool Add(T Entity);

    // Update methods

    Task<bool> UpdateAsync(string id);
    bool Update(T Entity);

    // Remove methods

}
