using Application.Models.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstraction;

namespace Presentation.Controllers;

public class HostController : ApiController
{
    private readonly IHostService _hostService;

    public HostController(IHostService hostService)
    {
        _hostService = hostService;
    }

    [HttpPost("AddNewBook")]
    public async Task<ActionResult<bool>> AddNewBook(AddBookRequest request)
    {
        return Ok(await _hostService.AddBookAsync(request));
    }

    [HttpPost("AddNewCourse")]
    public async Task<ActionResult<bool>> AddNewCourse(AddCourseRequest request)
    {
        return Ok(await _hostService.AddCourseAsync(request));
    }

    [HttpDelete("RemoveBook")]
    public async Task<ActionResult<bool>> RemoveBook(string bookId)
    {
        return Ok(await _hostService.RemoveBookAsync(bookId));
    }

    [HttpDelete("RemoveCourse")]
    public async Task<ActionResult<bool>> RemoveCourse(string courseId)
    {
        return Ok(await _hostService.RemoveCourseAsync(courseId));
    }

    [HttpPut("BanUser")]
    public async Task<ActionResult<bool>> BanUser(BanUserRequest request)
    {
        return Ok(await _hostService.BanUserAsync(request));
    }
}
