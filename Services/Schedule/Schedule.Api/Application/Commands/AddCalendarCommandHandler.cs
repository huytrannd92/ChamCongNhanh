using MediatR;
using Schedule.Domain.AggregatesModel.CalendarAggregate;

namespace Schedule.Api.Application.Commands
{
    public class AddCalendarCommandHandler : IRequestHandler<AddCalendarCommand, bool>
    {

        private readonly ICalendarRepository _calendarRepository;
        private readonly ILogger<AddCalendarCommandHandler> _logger;

        public AddCalendarCommandHandler(ICalendarRepository calendarRepository, ILogger<AddCalendarCommandHandler> logger)
        {
            _calendarRepository = calendarRepository ?? throw new ArgumentNullException(nameof(calendarRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(AddCalendarCommand request, CancellationToken cancellationToken)
        {
            var calendar = new Calendar(request.Year, request.Month, request.CompanyId);

            foreach (var item in request.ShiftConfigs)
            {
                calendar.AddShiftConfig(item.StartHour, item.EndHour);
            }

            _calendarRepository.Add(calendar);

            return await _calendarRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
