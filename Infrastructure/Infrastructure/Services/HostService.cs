using Application.Models.Requests;
using Application.Repositories;
using Application.Services;
using Domain.Models;
using Serilog;
using System.Net;

namespace Infrastructure.Services;

public class HostService : IHostService
{
    private readonly IUnitOfWork _unitOfWork;

    public HostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> AddBookAsync(AddBookRequest request)
    {
        var newBook = new Book()
        {
            Name = request.Name,
            AuthorFullName = request.AuthorFullName,
            Description = request.Description,
            Id = Guid.NewGuid().ToString(),
            OwnerCount = 0,
            Price = request.Price,
            Tags = request.Tags
        };

        var result = await _unitOfWork.WriteBookRepository.AddAsync(newBook);
        await _unitOfWork.WriteBookRepository.SaveChangesAsync();
        return result;
    }

    public async Task<bool> AddCourseAsync(AddCourseRequest request)
    {
        var newCourse = new Course()
        {
            Name = request.Name,
            Street = request.Street,
            SubscriberCount = 0,
            BookIds = new List<string>(),
            City = request.City,
            CommentIds = new List<string>(),
            Description = request.Description,
            FavCount = 0,
            FullAddress = request.FullAddress,
            Id = Guid.NewGuid().ToString(),
            LikeCount = 0,
            Rating = 0,
            Tags = request.Tags,
        };

        var result = await _unitOfWork.WriteCourseRepository.AddAsync(newCourse);
        await _unitOfWork.WriteCourseRepository.SaveChangesAsync();
        return result;
    }

    public async Task<bool> BanUserAsync(BanUserRequest request)
    {
        var user = await _unitOfWork.ReadUserRepository.GetAsync(request.UserId);
        if(user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        user.IsUserBanned = true;
        var result = await _unitOfWork.WriteUserRepository.UpdateAsync(request.UserId);
        await _unitOfWork.WriteUserRepository.SaveChangesAsync();

        Log.Information($"{user.Email} is banned, reason: \n {request.ReasonContent}");

        return result;
    }

    public Task<bool> ConfirmAndRemoveAccountAsync(RemoveMyAccountRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveBookAsync(string bookId)
    {
        var result = await _unitOfWork.WriteBookRepository.RemoveAsync(bookId);
        await _unitOfWork.WriteUserRepository.SaveChangesAsync();
        return result;
    }

    public async Task<bool> RemoveCourseAsync(string courseId)
    {
        var result = await _unitOfWork.WriteCourseRepository.RemoveAsync(courseId);
        await _unitOfWork.WriteCourseRepository.SaveChangesAsync();
        return result;
    }
}
