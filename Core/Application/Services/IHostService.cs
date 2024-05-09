using Application.Models.Requests;

namespace Application.Services;

public interface IHostService
{
    Task<bool> AddBookAsync(AddBookRequest request);
    Task<bool> RemoveBookAsync(string bookId);

    Task<bool> AddCourseAsync(AddCourseRequest request);
    Task<bool> RemoveCourseAsync(string courseId);

    bool BanUser(string userId);

    Task<bool> ConfirmAndRemoveAccount(RemoveMyAccountRequest request);
}
