using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace Schedule.Domain.AggregatesModel.ShiftAggregate;


public class Shift : Entity, IAggregateRoot
{
    private EmployeeInfo _employeeInfo;
    private int _calendarId;
    private DateTime _startHour;
    private DateTime _endHour;

    public Shift(int calendarId, DateTime startHour, DateTime endHour)
    {
        _calendarId = calendarId;
        _startHour = startHour;
        _endHour = endHour;
    }

    public void SetEmployee(int employeeId, string employeeName)
    {
        _employeeInfo = new EmployeeInfo()
        {
            EmployeeId = employeeId,
            EmployeeName = employeeName
        };
    }
    public void SetEmployee(EmployeeInfo employeeInfo)
    {
        _employeeInfo = employeeInfo;
    }
}

public class EmployeeInfo : ValueObject
{
    public int EmployeeId;
    public string EmployeeName;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return EmployeeId;
        yield return EmployeeName;
    }
}