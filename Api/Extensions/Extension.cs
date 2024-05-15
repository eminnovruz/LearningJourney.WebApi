﻿using Application.Repositories;
using Application.Repositories.BookRepository;
using Application.Repositories.CommentRepository;
using Application.Repositories.CourseRepository;
using Application.Repositories.UserRepository;
using Application.Services;
using Infrastructure.Services;
using Persistence.Repositories;
using Persistence.Repositories.BookRepository;
using Persistence.Repositories.CommentRepository;
using Persistence.Repositories.CourseRepository;
using Persistence.Repositories.UserRepository;

namespace Api.Extensions;

public static class Extension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPassHashService, PassHashService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IHostService, HostService>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IReadBookRepository, ReadBookRepository>();
        services.AddScoped<IWriteBookRepository, WriteBookRepository>();
        services.AddScoped<IReadUserRepository, ReadUserRepository>();
        services.AddScoped<IWriteUserRepository, WriteUserRepository>();
        services.AddScoped<IWriteCourseRepository, WriteCourseRepository>();
        services.AddScoped<IReadCourseRepository, ReadCourseRepository>();
        services.AddScoped<IReadCommentRepository, ReadCommentRepository>();
        services.AddScoped<IWriteCommentRepository, WriteCommentRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
