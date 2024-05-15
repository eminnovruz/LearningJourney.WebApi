﻿using Application.Exceptions;
using Application.Models.Requests;
using Application.Models.Responses;
using Application.Repositories;
using Application.Services;
using Domain.Models;

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

    public async Task<bool> MakeCommentAsync(MakeCommentRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var newComment = new Comment()
        {
            Id = Guid.NewGuid().ToString(),
            CommentDate = DateTime.Now,
            Content = request.Content,
            LikeCount = 0,
            UserId = request.UserId
        };

        var result = await _unitOfWork.WriteCommentRepository.AddAsync(newComment);
        await _unitOfWork.WriteCommentRepository.SaveChangesAsync();
        return result;
    }

    public Task<bool> RateCourse()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RateCourseAsync(RateCourseRequest request)
    {
        if (request.Rate > 5 || request.Rate < 1) 
        {
            throw new InvalidRatingException("The rating value must be between 1 and 5. Please provide a valid rating.");
        }

        var course = await _unitOfWork.ReadCourseRepository.GetAsync(request.CourseId);

        if (course is null)
        {
            throw new ArgumentNullException(nameof(course));
        }

        course.Rating = course.RatingsCount == 0 ? request.Rate : (course.Rating + request.Rate) / course.RatingsCount++;
        var result = _unitOfWork.WriteCourseRepository.Update(course);
        await _unitOfWork.WriteCourseRepository.SaveChangesAsync();
        return result;
    }

}
