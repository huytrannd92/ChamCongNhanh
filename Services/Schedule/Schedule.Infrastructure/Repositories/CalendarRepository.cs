using Schedule.Domain.AggregatesModel.CalendarAggregate;
using Schedule.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Infrastructure.Repositories
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly ScheduleContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CalendarRepository(ScheduleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Calendar Add(Calendar calendar)
        {
            return _context.Calendars.Add(calendar).Entity;
        }

    }
}
