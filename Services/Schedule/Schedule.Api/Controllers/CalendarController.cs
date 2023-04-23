using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Schedule.Api.Application.Queries;
using Schedule.Api.Application.Commands;
using MediatR;
using Schedule.Api.Infrastructure.Services;

namespace Schedule.Api.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize]
public class CalendarController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICalendarQueries _calendarQueries;
    private readonly IIdentityService _identityService;

    public CalendarController(ICalendarQueries calendarQueries, IIdentityService identityService, IMediator mediator)
    {
        _calendarQueries = calendarQueries;
        _identityService = identityService;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCalendarAsync()
    {

        return Ok();
    }

    [HttpGet]
    [Route("CalendarList")]
    public async Task<IActionResult> GetCalendarListAsync()
    {
        var userId = _identityService.GetUserIdentity();
        var calendarList =await  _calendarQueries.GetCalendarByUserIdAsync(userId.ToString());
        return Ok(calendarList);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCalendarAsync([FromBody] AddCalendarCommand cmd)
    {
        //var result = await _mediator.Send(cmd);


        return Ok();
    }
}