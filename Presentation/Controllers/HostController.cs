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
        try
        {
            return Ok(await _hostService.AddBookAsync(request));
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPost("AddNewCourse")]
    public async Task<ActionResult<bool>> AddNewCourse(AddCourseRequest request)
    {
        try
        {
            return Ok(await _hostService.AddCourseAsync(request));
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("RemoveBook")]
    public async Task<ActionResult<bool>> RemoveBook(string bookId)
    {
        try
        {
            return Ok(await _hostService.RemoveBookAsync(bookId));
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("RemoveCourse")]
    public async Task<ActionResult<bool>> RemoveCourse(string courseId)
    {
        try
        {
            return Ok(await _hostService.RemoveCourseAsync(courseId));
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}
