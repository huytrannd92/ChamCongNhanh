using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Schedule.Api.Application.Queries;
using Schedule.Api.Infrastructure.Services;

namespace Schedule.Tests;

public class TestCalendarController
{
    private readonly Mock<IMediator> _mediator;
    private readonly Mock<ICalendarQueries> _calendarQueriesMock;
    private readonly Mock<IIdentityService> _identityServiceMock;


    public TestCalendarController()
    {
        _calendarQueriesMock = new Mock<ICalendarQueries>();
        _identityServiceMock = new Mock<IIdentityService>();
        _mediator = new Mock<IMediator>();
    }

    [Fact]
    public async Task Get_CalendarListByUserId_ReturnStatusSucess200()
    {
        // Set up
        var fakeCalendarList = Enumerable.Empty<CalendarSummary>();
        _identityServiceMock.Setup(x => x.GetUserIdentity()).Returns(new Guid().ToString());
        _calendarQueriesMock.Setup(x => x.GetCalendarByUserIdAsync(It.IsAny<string>()))
            .Returns(Task.FromResult(fakeCalendarList));

        var controller = new CalendarController(_calendarQueriesMock.Object , _identityServiceMock.Object, _mediator.Object);

        // Execute
        var result = (OkObjectResult)await controller.GetCalendarListAsync();

        // Asserts
        result.StatusCode.Should().Be(200);

    }
}