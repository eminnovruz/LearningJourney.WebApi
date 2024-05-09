using Application.Repositories;
using Application.Repositories.BookRepository;
using Application.Services;
using Infrastructure.Services;
using Persistence.Repositories;
using Persistence.Repositories.BookRepository;

namespace Api.Extensions;

public static class Extension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPassHashService, PassHashService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IReadBookRepository, ReadBookRepository>();
        services.AddScoped<IWriteBookRepository, WriteBookRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
