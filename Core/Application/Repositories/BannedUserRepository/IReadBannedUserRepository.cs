using Application.Repositories.Repository;
using Domain.Models;

namespace Application.Repositories.BannedUserRepository;

public interface IReadBannedUserRepository : IReadRepository<BannedUser>
{
}
