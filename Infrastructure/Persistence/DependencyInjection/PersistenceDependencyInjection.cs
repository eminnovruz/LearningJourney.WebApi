using Application.Repositories.BookRepository;
using Application.Repositories.CommentRepository;
using Application.Repositories.CourseRepository;
using Application.Repositories.UserRepository;
using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.BookRepository;
using Persistence.Repositories.CommentRepository;
using Persistence.Repositories.CourseRepository;
using Persistence.Repositories.UserRepository;
using Persistence.Repositories;
using Application.Repositories.BannedUserRepository;
using Persistence.Repositories.BannedUserRepository;

namespace Persistence.DependencyInjection;

public static class PersistenceDependencyInjection
{
    public static IServiceCollection AddPersistenceRepositories(this IServiceCollection services)
    {
        services.AddScoped<IReadBookRepository, ReadBookRepository>();
        services.AddScoped<IWriteBookRepository, WriteBookRepository>();

        services.AddScoped<IReadUserRepository, ReadUserRepository>();
        services.AddScoped<IWriteUserRepository, WriteUserRepository>();

        services.AddScoped<IWriteCourseRepository, WriteCourseRepository>();
        services.AddScoped<IReadCourseRepository, ReadCourseRepository>();

        services.AddScoped<IReadCommentRepository, ReadCommentRepository>();
        services.AddScoped<IWriteCommentRepository, WriteCommentRepository>();

        services.AddScoped<IReadBannedUserRepository, ReadBannedUserRepository>();
        services.AddScoped<IWriteBannedUserRepository, WriteBannedUserRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

}
