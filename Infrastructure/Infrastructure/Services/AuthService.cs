using Application.Models.Requests;
using Application.Models.Responses;
using Application.Repositories;
using Application.Services;
using Azure.Core;
using Domain.Models;

namespace Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IPassHashService _passHashService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;

    public AuthService(IPassHashService passHashService, IUnitOfWork unitOfWork, IJwtService jwtService)
    {
        _passHashService = passHashService;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }

    public AuthTokenInfo GenerateToken(User user)
    {
        var token = _jwtService.GenerateSecurityToken(user.Id, user.Email, user.Role);
        user.RefreshToken = token.RefreshToken;
        user.TokenExpireDate = token.ExpireDate;
        return token;
    }

    public async Task<AuthTokenInfo> Login(LoginUserRequest request)
    {
        var user = await _unitOfWork.ReadUserRepository.GetAsync(req => req.Email == request.Email);

        if (user == null)
        {
            throw new ArgumentNullException("We cannot find an account related with this email.");
        }

        if (!_passHashService.ConfirmPasswordHash(request.Password, user.PassHash, user.PassSalt))
        {
            throw new ArgumentException("Wrong password.");
        }

        var token = GenerateToken(new User()
        {
            PassSalt = user.PassSalt,
            Email = user.Email,
            Id = user.Id,
            Name = user.Name,
            PassHash = user.PassHash,
            RefreshToken = user.RefreshToken,
            Role = user.Role,
            TokenExpireDate = user.TokenExpireDate,
        });

        await _unitOfWork.WriteUserRepository.UpdateAsync(user.Id);
        await _unitOfWork.WriteUserRepository.SaveChangesAsync();
        return token;
    }

    public async Task<AuthTokenInfo> RefreshToken(RefreshTokenRequest request)
    {
        if (request.ExpireDate >= DateTime.Now)
        {
            var user = await _unitOfWork.ReadUserRepository.GetAsync(req => req.RefreshToken == request.RefreshToken);
            if (user is not null)
            {
                var token = GenerateToken(new User()
                {
                    PassSalt = user.PassSalt,
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                    PassHash = user.PassHash,
                    RefreshToken = user.RefreshToken,
                    Role = user.Role,
                    TokenExpireDate = user.TokenExpireDate
                });
                await _unitOfWork.WriteUserRepository.UpdateAsync(user.Id);
                await _unitOfWork.WriteUserRepository.SaveChangesAsync();
                return token;
            }
        }

        throw new ArgumentException();
    }

    public async Task<bool> Register(RegisterUserRequest request)
    {
        var users = _unitOfWork.ReadUserRepository.GetAll().ToList();

        if (users.Any(user => user.Email == request.Email))
        {
            throw new ArgumentException("This email is aldeady used");
        }

        _passHashService.Create(request.Password, out byte[] passHash, out byte[] passSalt);

        var newUser = new User()
        {
            Name = request.Name,
            Surname = request.Surname,
            PassHash = passHash,
            PassSalt = passSalt,
            Email = request.Email,
            Id = Guid.NewGuid().ToString(),
            PhoneNumber = request.PhoneNumber,
            Role = "User",
            RefreshToken = "",
            TokenExpireDate = default,
            CommentIds = new List<string>(),
            SubscribedCourseIds = new List<string>(),
            FavouritesIds = new List<string>(),
            IsEmailConfirmed = false,
            IsUserBanned = false,
            ProfilePhotoId = "0",
        };

        var result = await _unitOfWork.WriteUserRepository.AddAsync(newUser);
        await _unitOfWork.WriteUserRepository.SaveChangesAsync();
        return result;
    }
}
