using Schedule.Domain.AggregatesModel.CompanyAggregate;
using Schedule.Domain.AggregatesModel.ShiftAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Domain.Services
{
    public class AllocationService : IAllocationService
    {
        public void AllocatateShifts(IEnumerable<Shift> shifts, Company company)
        {
            var employeeIds = company.Employees.Select(x => x.Id);

        }
    }
}
