using Application.Repositories;
using Application.Repositories.BookRepository;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IReadBookRepository readBookRepository, IWriteBookRepository writeBookRepository)
    {
        ReadBookRepository = readBookRepository;
        WriteBookRepository = writeBookRepository;
    }

    public IReadBookRepository ReadBookRepository { get; }
    public IWriteBookRepository WriteBookRepository { get; }
}
