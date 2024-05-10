using Domain.Models.Common;

namespace Domain.Models;

public class Course : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int SubscriberCount { get; set; }
    public List<string> Tags { get; set; }
    public int Rating { get; set; }
    public int RatingsCount { get; set; }
    public List<string> CommentIds { get; set; }
    public List<string> BookIds { get; set; }
    public int LikeCount { get; set; }
    public int FavCount { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string FullAddress { get; set; }
}
