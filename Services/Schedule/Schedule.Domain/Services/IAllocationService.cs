using Schedule.Domain.AggregatesModel.CalendarAggregate;
using Schedule.Domain.AggregatesModel.CompanyAggregate;
using Schedule.Domain.AggregatesModel.ShiftAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Domain.Services
{
    public interface IAllocationService
    {
        //IShiftRepository _shiftRepository;
        void AllocatateShifts(IEnumerable<Shift> shifts, Company company);
    }

}
