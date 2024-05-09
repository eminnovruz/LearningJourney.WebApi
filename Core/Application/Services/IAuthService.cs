using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Models;

namespace Application.Services;

public interface IAuthService
{
    Task<bool> Register(RegisterUserRequest request);
    Task<AuthTokenInfo> Login(LoginUserRequest request);
    AuthTokenInfo GenerateToken(User user);
    Task<AuthTokenInfo> RefreshToken(RefreshTokenRequest request);

}
