using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Services;

public interface IUserService
{
    IEnumerable<CourseInfo> GetAllCourses();
    IEnumerable<CommentInfo> GetMyComments(string userId);
    IEnumerable<BookInfo> GetAllBooks();
    Task<IEnumerable<CourseInfo>> SearchCoursesAsync(string text);
    Task<IEnumerable<BookInfo>> SearchBooksAsync(string text);
    Task<bool> RateCourseAsync(RateCourseRequest request);
    Task<bool> MakeCommentAsync(MakeCommentRequest request);
    Task<bool> AddCourseToFavouritesAsync(AddCourseToFavRequest request);
}
