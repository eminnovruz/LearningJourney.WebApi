using Application.Models.Requests;
using Application.Models.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                return Ok(_userService.GetAllBooks());
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            try
            {
                return Ok(_userService.GetAllCourses());
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("RateCourse")]
        public async Task<IActionResult> RateCourse(RateCourseRequest request)
        {
            try
            {
                return Ok(await _userService.RateCourseAsync(request));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("MakeComment")]
        public async Task<IActionResult> MakeComment(MakeCommentRequest request)
        {
            try
            {
                return Ok(await _userService.MakeCommentAsync(request));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetMyComments")]
        public IActionResult GetMyComments(string userId)
        {
            try
            {
                return Ok(_userService.GetMyComments(userId));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
