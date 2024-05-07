using Domain.Models.Common;

namespace Domain.Models;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ProfilePhotoId { get; set; }
    public List<string> SubscribedCourseIds { get; set; }
    public List<string> CommentIds { get; set; }
    public List<string> FavouritesIds { get; set; }
}
