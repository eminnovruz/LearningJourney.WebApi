using Application.Services;
using Infrastructure.BackgroundServices;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Infrastructure.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IHostService, HostService>();

        services.AddScoped<IAuthService, AuthService>();

        // helper services

        services.AddScoped<IPassHashService, PassHashService>();

        services.AddScoped<IJwtService, JwtService>();

        services.AddScoped<IBlobService, BlobService>();

        // hosted services

        services.AddHostedService<ForbiddenCommentChecker>();

        return services;
    }
}
