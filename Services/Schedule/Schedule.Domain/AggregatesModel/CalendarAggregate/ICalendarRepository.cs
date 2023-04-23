using System.Globalization;

namespace Schedule.Domain.AggregatesModel.CalendarAggregate;

public interface ICalendarRepository : IRepository<Calendar>
{
    Calendar Add(Calendar calendar);

    //void Update(Calendar calendar);

    //Task<Calendar> GetAsync(int calendarId);
}