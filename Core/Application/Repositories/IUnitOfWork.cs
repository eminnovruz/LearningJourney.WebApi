using Application.Repositories.BookRepository;
using Application.Repositories.CommentRepository;
using Application.Repositories.CourseRepository;
using Application.Repositories.UserRepository;

namespace Application.Repositories;

public interface IUnitOfWork
{
    IReadBookRepository ReadBookRepository { get; }
    IWriteBookRepository WriteBookRepository { get; }

    IReadUserRepository ReadUserRepository { get; }
    IWriteUserRepository WriteUserRepository { get; }

    IReadCourseRepository ReadCourseRepository { get; }
    IWriteCourseRepository WriteCourseRepository { get; }
    IReadCommentRepository ReadCommentRepository { get; }
    IWriteCommentRepository WriteCommentRepository { get;}
}
