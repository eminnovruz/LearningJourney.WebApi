using Application.Repositories.CommentRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.CommentRepository;

public class WriteCommentRepository : WriteRepository<Comment>, IWriteCommentRepository
{
    public WriteCommentRepository(AppDbContext context) : base(context)
    {
    }
}
