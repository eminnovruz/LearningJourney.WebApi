using Domain.Models.Common;

namespace Domain.Models;

public class BannedUser : BaseEntity
{
    public string UserId { get; set; }
    public string ReasonContent { get; set; }
    public DateTime BannedDate { get; set; }
    public DateTime UnbanDate { get; set; }
}
