using Application.Models.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostController : ControllerBase
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
    }
}
