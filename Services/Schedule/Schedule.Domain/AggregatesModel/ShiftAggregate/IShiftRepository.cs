namespace Schedule.Domain.AggregatesModel.ShiftAggregate;

public interface IShiftRepository : IRepository<Shift>
{
    Shift Add(Shift shift);


}