using Application.Models.Requests;
using Application.Models.Responses;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginUserRequest request)
        {
            try
            {
                return Ok(await _authService.Login(request));
            }
            catch (Exception)
            {
                return BadRequest("Error occured with loginning");
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserRequest request)
        {
            try
            {
                if (await _authService.Register(request))
                {
                    return Ok("Successfully Registered!");
                }
                throw new ArgumentException("Error occured with registering, try again later.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<AuthTokenInfo>> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var token = await _authService.RefreshToken(request);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
