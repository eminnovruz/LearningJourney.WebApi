using Microsoft.AspNetCore.Mvc;

namespace Presentation.Abstraction;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
}
