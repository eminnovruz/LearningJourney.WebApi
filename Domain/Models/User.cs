using Domain.Models.Common;

namespace Domain.Models;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public string ProfilePhotoId { get; set; }
    public List<string> SubscribedCourseIds { get; set; }
    public List<string> CommentIds { get; set; }
    public List<string> FavouritesIds { get; set; }
    public byte[] PassHash { get; set; }
    public byte[] PassSalt { get; set; }
    public string Role { get; set; }
    public string RefreshToken { get; set; }
    public DateTime TokenExpireDate { get; set; }
}
