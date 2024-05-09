using Application.Models.Configurations;
using Application.Models.Responses;
using Application.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services;

public class JwtService : IJwtService
{
    private readonly JwtConfiguration _config;

    public JwtService(JwtConfiguration config)
    {
        _config = config;
    }

    public AuthTokenInfo GenerateSecurityToken(string id, string email, string role)
    {
        var authTokenDto = new AuthTokenInfo();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var claims = new[]{
            new Claim(ClaimsIdentity.DefaultNameClaimType, email),
            new Claim("userId", id),
            new Claim(ClaimTypes.Role , role)
        };


        var token = new JwtSecurityToken(
            issuer: _config.Issuer,
            audience: _config.Audience,
            expires: DateTime.Now.AddHours(_config.ExpiresDate),
            notBefore: DateTime.Now,
            claims: claims,
            signingCredentials: signingCredentials
            );

        authTokenDto.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

        byte[] numbers = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(numbers);

        authTokenDto.RefreshToken = Convert.ToBase64String(numbers);
        authTokenDto.ExpireDate = DateTime.Now.AddHours(_config.ExpiresDate).AddMinutes(10);

        return authTokenDto;
    }
}
