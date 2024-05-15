using Application.Repositories.CommentRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.CommentRepository;

public class ReadCommentRepository : ReadRepository<Comment>, IReadCommentRepository
{
    public ReadCommentRepository(AppDbContext context) : base(context)
    {
    }
}
