using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Schedule.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ShiftsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}