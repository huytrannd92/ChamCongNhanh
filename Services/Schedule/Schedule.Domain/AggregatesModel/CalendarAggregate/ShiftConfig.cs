using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Domain.AggregatesModel.CalendarAggregate
{
    public class ShiftConfig : Entity
    {
        // DDD Patterns comment
        // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
        // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)

        public DateTime StartHour { get; private set; }
        public DateTime EndHour { get;private set; }

        public int CalendarId { get; set; }

        protected ShiftConfig() { }

        public ShiftConfig(DateTime startHour, DateTime endHour) :this() {
            StartHour = startHour;
            EndHour = endHour;
        }



    }
}
