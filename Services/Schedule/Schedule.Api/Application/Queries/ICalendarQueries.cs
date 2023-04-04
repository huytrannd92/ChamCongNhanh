namespace Schedule.Api.Application.Queries;

public interface ICalendarQueries
{
    Task<CalendarDto> GetCalendarByIdAsync(int calendarId);
    Task<IEnumerable<CalendarSummary>> GetCalendarByUserIdAsync(string userId);


}
