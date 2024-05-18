using Application.Repositories;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Infrastructure.BackgroundServices;

public class ForbiddenCommentChecker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Log.Information("Forbidden Message Checker -- B Service started working.");
    }
}
