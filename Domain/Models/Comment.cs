using Domain.Models.Common;

namespace Domain.Models;

public class Comment : BaseEntity
{
    public DateTime CommentDate { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }
    public int LikeCount { get; set; }
}
