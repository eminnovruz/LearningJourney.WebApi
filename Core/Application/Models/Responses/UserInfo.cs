namespace Application.Models.Responses;

public class UserInfo
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<string> CommentIds { get; set; }
    public string ImageUrl { get; set; }
}
