namespace Schedule.Api.Application.Queries;

public class CalendarQueries : ICalendarQueries
{
    public CalendarQueries(string connectionString)
    {

    }
    public Task<CalendarDto> GetCalendarByIdAsync(int calendarId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CalendarSummary>> GetCalendarByUserIdAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
