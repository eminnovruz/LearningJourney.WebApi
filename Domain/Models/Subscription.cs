using Domain.Models.Common;

namespace Domain.Models;

public class Subscription : BaseEntity
{
    public DateTime SubscribedOn { get; set; }
    public DateTime ExpireDate { get; set; }
    public string CourseId { get; set; }
    public string UserId { get; set; }
    public int Price { get; set; }
}
