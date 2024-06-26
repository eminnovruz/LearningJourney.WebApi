﻿using Application.Repositories;
using Application.Repositories.BannedUserRepository;
using Application.Repositories.BookRepository;
using Application.Repositories.CommentRepository;
using Application.Repositories.CourseRepository;
using Application.Repositories.UserRepository;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IReadBookRepository readBookRepository, IWriteBookRepository writeBookRepository, IReadUserRepository readUserRepository, IWriteUserRepository writeUserRepository, IReadCourseRepository readCourseRepository, IWriteCourseRepository writeCourseRepository, IReadCommentRepository readCommentRepository, IWriteCommentRepository writeCommentRepository, IReadBannedUserRepository readBannedUserRepository, IWriteBannedUserRepository writeBannedUserRepository)
    {
        ReadBookRepository = readBookRepository;
        WriteBookRepository = writeBookRepository;
        ReadUserRepository = readUserRepository;
        WriteUserRepository = writeUserRepository;
        ReadCourseRepository = readCourseRepository;
        WriteCourseRepository = writeCourseRepository;
        ReadCommentRepository = readCommentRepository;
        WriteCommentRepository = writeCommentRepository;
        ReadBannedUserRepository = readBannedUserRepository;
        WriteBannedUserRepository = writeBannedUserRepository;
    }

    public IReadBookRepository ReadBookRepository { get; }
    public IWriteBookRepository WriteBookRepository { get; }
    public IReadUserRepository ReadUserRepository  { get; }
    public IWriteUserRepository WriteUserRepository { get; }
    public IReadCourseRepository ReadCourseRepository { get;  }
    public IWriteCourseRepository WriteCourseRepository { get; }
    public IReadCommentRepository ReadCommentRepository { get; }
    public IWriteCommentRepository WriteCommentRepository { get; }
    public IReadBannedUserRepository ReadBannedUserRepository { get; }
    public IWriteBannedUserRepository WriteBannedUserRepository { get; }
}
