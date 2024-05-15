using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Services;

public interface IUserService
{
    IEnumerable<CourseInfo> GetAllCourses();
    IEnumerable<CommentInfo> GetMyComments(string userId);
    IEnumerable<BookInfo> GetAllBooks();
    Task<bool> RateCourseAsync(RateCourseRequest request);
    Task<bool> MakeCommentAsync(MakeCommentRequest request);
}
