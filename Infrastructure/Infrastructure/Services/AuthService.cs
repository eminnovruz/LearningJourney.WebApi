using Application.Exceptions;
using Application.Models.Requests;
using Application.Models.Responses;
using Application.Repositories;
using Application.Services;
using Azure.Core;
using Domain.Models;
using Serilog;

namespace Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IPassHashService _passHashService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
    private readonly IBlobService _blobService;

    public AuthService(IPassHashService passHashService, IUnitOfWork unitOfWork, IJwtService jwtService, IBlobService blobService)
    {
        _passHashService = passHashService;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
        _blobService = blobService;
    }

    public AuthTokenInfo GenerateToken(User user)
    {
        var token = _jwtService.GenerateSecurityToken(user.Id, user.Email, user.Role);
        user.RefreshToken = token.RefreshToken;
        user.TokenExpireDate = token.ExpireDate;
        Log.Information($"{user.Email} has generated token");
        return token;
    }

    public async Task<AuthTokenInfo> Login(LoginUserRequest request)
    {
        var user = await _unitOfWork.ReadUserRepository.GetAsync(req => req.Email == request.Email) ?? throw new UserNotFoundException();

        if (!_passHashService.ConfirmPasswordHash(request.Password, user.PassHash, user.PassSalt))
            throw new WrongPasswordException();

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
        Log.Information($"{user.Email} -- Login");

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

        throw new Exception();
    }

    public async Task<bool> Register(RegisterUserRequest request)
    {
        var users = _unitOfWork.ReadUserRepository.GetAll().ToList();

        if (users.Any(user => user.Email == request.Email))
            throw new EmailUsedException();

        using (var stream = request.ProfilePhoto.OpenReadStream())
        {
            var fileName = Guid.NewGuid().ToString() + request.Email;
            var contentType = request.ProfilePhoto.ContentType;
            await _blobService.UploadFileAsync(stream, fileName, contentType);
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
            ProfilePhoto = request.ProfilePhoto
        };

        var result = await _unitOfWork.WriteUserRepository.AddAsync(newUser);
        await _unitOfWork.WriteUserRepository.SaveChangesAsync();
        Log.Information($"{newUser.Email} -- Registered");

        return result;
    }
}
