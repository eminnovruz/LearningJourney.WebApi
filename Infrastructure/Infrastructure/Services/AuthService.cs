using Application.Models.Requests;
using Application.Models.Responses;
using Application.Services;
using Domain.Models;

namespace Infrastructure.Services;

public class AuthService : IAuthService
{
    public AuthTokenInfo GenerateToken(User user)
    {
        throw new NotImplementedException();
    }

    public Task<AuthTokenInfo> Login(LoginUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<AuthTokenInfo> RefreshToken(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Register(RegisterUserRequest request)
    {
        throw new NotImplementedException();
    }
}
