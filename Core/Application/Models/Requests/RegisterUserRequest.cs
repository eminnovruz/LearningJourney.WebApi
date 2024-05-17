using Microsoft.AspNetCore.Http;

namespace Application.Models.Requests;

public class RegisterUserRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public IFormFile ProfilePhoto { get; set; }
}
