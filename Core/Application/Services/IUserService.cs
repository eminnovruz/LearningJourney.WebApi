using Application.Models.Responses;

namespace Application.Services;

public interface IUserService
{
    IEnumerable<CourseInfo> GetAllCourses();
    IEnumerable<CommentInfo> GetMyComments();

}
