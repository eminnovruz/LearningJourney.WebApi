namespace Application.Models.Requests;

public class BanUserRequest
{
    public string UserId { get; set; }
    public DateTime BanDate { get; set; }
    public string ReasonContent { get; set; }
    public bool UnbanWithHours { get; set; } = true;
    public double UnbanAfterHours { get; set; }
    public int UnbanAfterMonths { get; set; }
}
