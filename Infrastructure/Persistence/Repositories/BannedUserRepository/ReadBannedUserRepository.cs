using Application.Repositories.BannedUserRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.BannedUserRepository;

public class ReadBannedUserRepository : ReadRepository<BannedUser>, IReadBannedUserRepository
{
    public ReadBannedUserRepository(AppDbContext context) : base(context)
    {
    }
}
