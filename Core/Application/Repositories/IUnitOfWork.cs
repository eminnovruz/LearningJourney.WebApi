using Application.Repositories.BookRepository;
using Application.Repositories.UserRepository;

namespace Application.Repositories;

public interface IUnitOfWork
{
    IReadBookRepository ReadBookRepository { get; }
    IWriteBookRepository WriteBookRepository { get; }

    IReadUserRepository ReadUserRepository { get; }
    IWriteUserRepository WriteUserRepository { get; }
}
