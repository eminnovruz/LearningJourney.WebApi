using Application.Models.Requests;
using Application.Repositories;
using Application.Services;

namespace Infrastructure.Services;

public class HostService : IHostService
{
    private readonly IUnitOfWork _unitOfWork;

    public HostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<bool> AddBookAsync(AddBookRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddCourseAsync(AddCourseRequest request)
    {
        throw new NotImplementedException();
    }

    public bool BanUser(string userId)
    {
        throw new NotImplementedException();
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
