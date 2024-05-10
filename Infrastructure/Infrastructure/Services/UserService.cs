using Application.Models.Responses;
using Application.Repositories;
using Application.Services;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<BookInfo> GetAllBooks()
    {
        var books = _unitOfWork.ReadBookRepository.GetAll();

        if (books is null)
        {
            throw new ArgumentNullException();
        }

        return books.Select(item => new BookInfo
        {
            Name = item.Name,
            Description = item.Description,
            AuthorFullName = item.AuthorFullName,
            Id = item.Id,
            OwnerCount = item.OwnerCount,
            Price = item.Price
        }).ToList();
    }

    public IEnumerable<CourseInfo> GetAllCourses()
    {
        var courses = _unitOfWork.ReadCourseRepository.GetAll();

        if(courses is null)
        {
            throw new ArgumentNullException(nameof(courses));
        }

        return courses.Select(item => new CourseInfo
        {
            Name = item.Name,
            Street = item.Street,
            SubscriberCount = item.SubscriberCount,
            City = item.City,
            CommentIds = item.CommentIds,
            Description = item.Description,
            FavCount = item.FavCount,
            FullAddress = item.FullAddress,
            LikeCount = item.LikeCount,
            Rating = item.Rating,
            Tags = item.Tags,
        });
    }

    public IEnumerable<CommentInfo> GetMyComments()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RateCourse()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RateCourse(string courseId, int rate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RateCourseByName(string courseName, int rate)
    {
        throw new NotImplementedException();
    }
}
