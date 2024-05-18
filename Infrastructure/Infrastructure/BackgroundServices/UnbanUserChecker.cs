using Application.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Infrastructure.BackgroundServices;

public class UnbanUserChecker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private IUnitOfWork _unitOfWork;

    public UnbanUserChecker(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;

        GetRequiredService();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Log.Information("Unban checker service started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(15000, stoppingToken);

            var bannedUsers = await _unitOfWork.ReadBannedUserRepository.GetAllAsync();

            foreach (var item in bannedUsers)
            {
                if (DateTime.Now > item.UnbanDate)
                {
                    var user = await _unitOfWork.ReadUserRepository.GetAsync(item.UserId);

                    if (user is null)
                        throw new ApplicationException();

                    user.IsUserBanned = false;

                    await _unitOfWork.WriteUserRepository.UpdateAsync(user.Id);
                    await _unitOfWork.WriteUserRepository.SaveChangesAsync();

                    Log.Information($"{user.Email} is unbanned at {item.UnbanDate}.");
                }
            }
        }

        Log.Information("Unban checker service is no longer checking.");
    }

    private void GetRequiredService()
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}
