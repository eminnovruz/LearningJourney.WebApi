using Application.Models.Responses;

namespace Application.Services;

public interface IJwtService
{
    AuthTokenInfo GenerateSecurityToken(string id, string email, string role);
}
