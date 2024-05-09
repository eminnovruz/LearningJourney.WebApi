using Application.Repositories.Repository;
using Domain.Models;

namespace Application.Repositories.BookRepository;

public interface IWriteBookRepository : IWriteRepository<Book>
{
}
