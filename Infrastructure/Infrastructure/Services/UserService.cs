using Application.Exceptions;
using Application.Models.Requests;
using Application.Models.Responses;
using Application.Repositories;
using Application.Services;
using Domain.Models;
using Serilog;

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
        var courses = _unitOfWork.ReadCourseRepository.GetAll() ?? throw new CourseNotFoundException();

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

    public IEnumerable<CommentInfo> GetMyComments(string userId)
    {
        var comments = _unitOfWork.ReadCommentRepository.GetWhere(x => x.UserId == userId).ToList();

        if(comments is null)
        {
            throw new ArgumentNullException();
        }

        return comments.Select(item => new CommentInfo()
        {
            CommentDate = item.CommentDate,
            Content = item.Content,
            LikeCount = item.LikeCount,
            UserId = userId,
        });
    }

    public async Task<bool> MakeCommentAsync(MakeCommentRequest request)
    {
        if (request == null)
            throw new ArgumentNullException();

        var user = await _unitOfWork.ReadUserRepository.GetAsync(request.UserId);
        var course = await _unitOfWork.ReadCourseRepository.GetAsync(request.CourseId);
        
        if (user.IsUserBanned)
            throw new BannedUserAttempException();

        if (user == null || course == null)
            throw new UserNotFoundException();

        var newComment = CreateNewComment(request);

        UpdateUserAndCourseComments(user, course, newComment);

        var result = await AddNewComment(newComment);

        await _unitOfWork.WriteCourseRepository.SaveChangesAsync();

        return result;
    }

    private async Task<bool> AddNewComment(Comment newComment)
    {
        return await _unitOfWork.WriteCommentRepository.AddAsync(newComment);
    }

    public async Task<bool> RateCourseAsync(RateCourseRequest request)
    {
        if (request.Rate > 5 || request.Rate < 1) 
            throw new InvalidRatingException();

        var course = await _unitOfWork.ReadCourseRepository.GetAsync(request.CourseId)??
            throw new CourseNotFoundException();

        course.Rating = course.RatingsCount == 0 ? request.Rate : (course.Rating + request.Rate) / course.RatingsCount++;
        var result = _unitOfWork.WriteCourseRepository.Update(course);
        await _unitOfWork.WriteCourseRepository.SaveChangesAsync();
        return result;
    }

    public async Task<bool> AddCourseToFavouritesAsync(AddCourseToFavRequest request)
    {
        var course = await _unitOfWork.ReadCourseRepository.GetAsync(request.CourseId) ?? throw new CourseNotFoundException();
        course.FavCount++;

        var user = await _unitOfWork.ReadUserRepository.GetAsync(request.UserId) ?? throw new UserNotFoundException();
        user.FavouritesIds.Add(course.Id);

        await _unitOfWork.WriteUserRepository.UpdateAsync(user.Id);
        await _unitOfWork.WriteCourseRepository.UpdateAsync(course.Id);

        await _unitOfWork.WriteUserRepository.SaveChangesAsync();

        return true;
    }


    // Helper Methods

    private Comment CreateNewComment(MakeCommentRequest request)
    {
        return new Comment
        {
            Id = Guid.NewGuid().ToString(),
            CommentDate = DateTime.Now,
            Content = request.Content,
            LikeCount = 0,
            UserId = request.UserId
        };
    }

    private void UpdateUserAndCourseComments(User user, Course course, Comment newComment)
    {
        user.CommentIds.Add(newComment.Id);
        course.CommentIds.Add(newComment.Id);
    }

    public Task<IEnumerable<CourseInfo>> SearchCoursesAsync(string text)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BookInfo>> SearchBooksAsync(string text)
    {
        var books = await _unitOfWork.ReadBookRepository.GetAllAsync() ?? throw new NullReferenceException();

        var searchResultBooks = new List<BookInfo>();

        foreach (var item in books)
        {
            text = text.ToLower();
            var name = item.Name.ToLower();

            if (name == text || name.Contains(text) || item.AuthorFullName.ToLower() == text || item.AuthorFullName.ToLower().Contains(text) || item.Tags.Contains(text))
            {
                AddFoundedBookAndLog(searchResultBooks, item);
            }
        }

        return searchResultBooks;
    }

    private static void AddFoundedBookAndLog(List<BookInfo> searchResultBooks, Book item)
    {
        searchResultBooks.Add(new BookInfo()
        {
            AuthorFullName = item.AuthorFullName,
            Description = item.Description,
            Id = item.Id,
            Name = item.Name,
            OwnerCount = item.OwnerCount,
            Price = item.Price,
        });

        Log.Information("Searched book found and added to results");
    }

}
