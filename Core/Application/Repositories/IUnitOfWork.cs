using Application.Repositories.BookRepository;

namespace Application.Repositories;

public interface IUnitOfWork
{
    IReadBookRepository ReadBookRepository { get; }
    IWriteBookRepository WriteBookRepository { get; }
}
