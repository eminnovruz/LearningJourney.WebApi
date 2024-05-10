using Application.Models.Requests;
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

        if (courses is null)
        {
            throw new ArgumentNullException();
        }

        return courses.Select(item => new CourseInfo
        {
            Id = item.Id,
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
        }).ToList();
    }

    public IEnumerable<CommentInfo> GetMyComments()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RateCourse()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RateCourse(RateCourseRequest request)
    {
        var course = await _unitOfWork.ReadCourseRepository.GetAsync(request.CourseId);

        if (course is null)
        {
            throw new ArgumentNullException(nameof(course));
        }

        course.Rating = CalculateRating(course.RatingsCount, course.Rating, request.Rate);
        var result = _unitOfWork.WriteCourseRepository.Update(course);
        return result;
    }

    public int CalculateRating(int ratingCount, int rating, int newRate)
        => (rating + newRate) / ratingCount++;

}
