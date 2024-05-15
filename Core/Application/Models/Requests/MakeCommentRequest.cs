namespace Application.Models.Requests;

public class MakeCommentRequest
{
    public string CourseId { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }
}
