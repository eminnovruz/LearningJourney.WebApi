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
        throw new NotImplementedException();
    }

    public IEnumerable<CommentInfo> GetMyComments()
    {
        throw new NotImplementedException();
    }
}
