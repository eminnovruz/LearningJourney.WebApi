using Application.Repositories.BookRepository;
using Application.Repositories.Repository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.BookRepository;

public class ReadBookRepository : ReadRepository<Book>, IReadBookRepository
{
    public ReadBookRepository(AppDbContext context) : base(context)
    {
    }
}
