using System.Net;

namespace Schedule.Domain.AggregatesModel.CalendarAggregate;

public class Calendar : Entity, IAggregateRoot
{
    // DDD Patterns comment
    // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
    // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)
    /***
     * Refer ARD 006, ADR 007
     ***/
    private int _year { get; set; }
    private int _month { get; set; }
    public int CompanyId => _companyId;
    private int _companyId;

    private List<ShiftConfig> _shiftConfigs;
    public IReadOnlyCollection<ShiftConfig> ShiftConfigs
    {
        get
        {
            return _shiftConfigs;
        }
    }

    protected Calendar()
    {
        _shiftConfigs = new List<ShiftConfig>();
    }


    public Calendar(int year, int month, int companyId) : this()
    {
        _year = year;
        _month = month;
        _companyId = companyId;
    }

  public  void AddShiftConfig(DateTime startHour, DateTime endHour)
    {
        var existingShiftConfig = _shiftConfigs.SingleOrDefault(o => o.StartHour == startHour && o.EndHour == endHour);
        if (existingShiftConfig != null)
        {
            return;
        }
        _shiftConfigs.Add(new ShiftConfig(startHour, endHour));
    }
}