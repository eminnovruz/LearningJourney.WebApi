using Application.Repositories.Repository;
using Domain.Models;

namespace Application.Repositories.CommentRepository;

public interface IWriteCommentRepository : IWriteRepository<Comment>
{
}
