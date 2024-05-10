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
        public ActionResult<BookInfo> GetAllBooks()
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
        public ActionResult<CourseInfo> GetAllCourses()
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
    }
}
