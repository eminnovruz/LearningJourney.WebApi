using Application.Models.Requests;
using Application.Repositories;
using Application.Services;
using Domain.Models;

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

    public Task<bool> AddCourseAsync(AddCourseRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> BanUser(string userId)
    {
        var user = await _unitOfWork.ReadUserRepository.GetAsync(userId);
        if(user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        user.IsUserBanned = true;
        var result = await _unitOfWork.WriteUserRepository.UpdateAsync(userId);
        return result;
    }

    public Task<bool> ConfirmAndRemoveAccount(RemoveMyAccountRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveBookAsync(string bookId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveCourseAsync(string courseId)
    {
        throw new NotImplementedException();
    }
}
