using Application.Repositories.Repository;
using Domain.Models;

namespace Application.Repositories.BookRepository;

public interface IReadBookRepository : IReadRepository<Book>
{
}
