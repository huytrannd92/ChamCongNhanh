using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schedule.Api.Application.Commands;
using Schedule.Api.Infrastructure.Services;
using Schedule.Domain.AggregatesModel.CalendarAggregate;

namespace Schedule.Tests.Application.Commands;

public class TestCalendarCommandHandlers
{
    private readonly Mock<IMediator> _mediator;

    private readonly Mock<IIdentityService> _identityServiceMock;
    private readonly Mock<ICalendarRepository> _calendarRepositoryMock;


    public TestCalendarCommandHandlers()
    {

        _identityServiceMock = new Mock<IIdentityService>();
        _mediator = new Mock<IMediator>();
        _calendarRepositoryMock = new Mock<ICalendarRepository>();
    }

    [Fact]
    public async Task Add_NewCalendar_ReturnCreated201()
    {
        // Set up
        var cmd = new AddCalendarCommand();
        var loggerMock = new Mock<ILogger<AddCalendarCommandHandler>>();

        var handler = new AddCalendarCommandHandler(_calendarRepositoryMock.Object, loggerMock.Object);
        var clToken = CancellationToken.None;
        // Execute
        var result = await handler.Handle(cmd, clToken);

        // Asserts
        result.Should().Be(true);

    }

    // [Fact]
    //public async Task Add_NewCalendar_ViolatedOverlapShiftConfigDuration()
    //{
    //    // Set up
        
    //    var cmd = new AddCalendarCommand();
    //    var handler = new AddCalendarHandler();

    //    // Execute
    //    var result = await handler.Handle(cmd);

    //    // Asserts
    //    result.Id.ShouldNot().Be(0);

    //}

    private AddCalendarCommand CreateFakeAddCalendarCmd(){
        var cmd  = new AddCalendarCommand();

        //cmd.UserId = new Guid().ToString();

        //var shiftConfigs= new List<ShiftConfig>(){

        //}
        return cmd;

    }


}
