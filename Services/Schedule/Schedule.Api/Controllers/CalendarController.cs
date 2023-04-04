using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Schedule.Api.Application.Queries;
using Schedule.Infrastructure.Services;

namespace Schedule.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CalendarController : ControllerBase
{
    private readonly ICalendarQueries _calendarQueries;
    private readonly IIdentityService _identityService;

    public CalendarController(ICalendarQueries calendarQueries, IIdentityService identityService)
    {
        _calendarQueries = calendarQueries;
        _identityService = identityService;
    }

    [HttpGet(Name = "currentMonth")]
    public async Task<IActionResult> GetCurrentMonthAsync()
    {
        return Ok("good");
    }

    [HttpGet(Name = "CalendarList")]
    public async Task<IActionResult> GetCalendarListAsync()
    {
        var userId = _identityService.GetUserIdentity();
        var calendarList =await  _calendarQueries.GetCalendarByUserIdAsync(userId.ToString());
        return Ok(calendarList);
    }
}