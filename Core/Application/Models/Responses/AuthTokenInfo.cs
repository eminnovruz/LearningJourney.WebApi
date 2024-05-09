namespace Application.Models.Responses;

public class AuthTokenInfo
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpireDate { get; set; }
}
