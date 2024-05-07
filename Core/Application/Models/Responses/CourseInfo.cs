namespace Application.Models.Responses;

public class CourseInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int SubscriberCount { get; set; }
    public List<string> Tags { get; set; }
    public int Rating { get; set; }
    public List<string> CommentIds { get; set; }
    public int LikeCount { get; set; }
    public int FavCount { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string FullAddress { get; set; }
}
