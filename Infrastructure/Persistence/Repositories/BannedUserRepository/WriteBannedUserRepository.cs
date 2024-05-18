using Application.Repositories.BannedUserRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.BannedUserRepository;

public class WriteBannedUserRepository : WriteRepository<BannedUser>, IWriteBannedUserRepository
{
    public WriteBannedUserRepository(AppDbContext context) : base(context)
    {
    }
}
