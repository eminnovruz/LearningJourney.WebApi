using Application.Repositories.BookRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.BookRepository;

public class WriteBookRepository : WriteRepository<Book>, IWriteBookRepository
{
    public WriteBookRepository(AppDbContext context) : base(context)
    {
    }
}
