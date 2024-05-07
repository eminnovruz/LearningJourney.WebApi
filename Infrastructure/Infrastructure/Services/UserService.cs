using Application.Models.Responses;
using Application.Services;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    public IEnumerable<CourseInfo> GetAllCourses()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CommentInfo> GetMyComments()
    {
        throw new NotImplementedException();
    }
}
