using Application.Models.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstraction;

namespace Presentation.Controllers;

public sealed class UserController : ApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetAllBooks")]
    public IActionResult GetAllBooks()
    {
        return Ok(_userService.GetAllBooks());
    }

    [HttpGet("GetAllCourses")]
    public IActionResult GetAllCourses()
    {
        return Ok(_userService.GetAllCourses());
    }

    [HttpPut("RateCourse")]
    public async Task<IActionResult> RateCourse(RateCourseRequest request)
    {
        return Ok(await _userService.RateCourseAsync(request));
    }

    [HttpPost("MakeComment")]
    public async Task<IActionResult> MakeComment(MakeCommentRequest request)
    {
        return Ok(await _userService.MakeCommentAsync(request));
    }

    [HttpGet("GetMyComments")]
    public IActionResult GetMyComments(string userId)
    {
        return Ok(_userService.GetMyComments(userId));
    }

    [HttpPut("AddCourseToFavourites")]
    public async Task<IActionResult> AddCourseToFavourites(AddCourseToFavRequest request)
    {
        return Ok(await _userService.AddCourseToFavouritesAsync(request));
    }

    [HttpGet("SearchBook")]
    public async Task<IActionResult> SearchBooks(string text)
    {
        return Ok(await _userService.SearchBooksAsync(text));
    }
}
