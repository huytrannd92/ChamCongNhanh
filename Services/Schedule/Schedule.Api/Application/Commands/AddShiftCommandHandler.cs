using MediatR;
using Schedule.Domain.AggregatesModel.CalendarAggregate;
using Schedule.Domain.AggregatesModel.ShiftAggregate;

namespace Schedule.Api.Application.Commands
{
    public class AddShiftCommandHandler : IRequestHandler<AddShiftCommand, bool>
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly ILogger<AddShiftCommandHandler> _logger;

        public Task<bool> Handle(AddShiftCommand request, CancellationToken cancellationToken)
        {
            var shift = new Shift(request.CalendarId, request.StartHour, request.EndHour);
            _shiftRepository.Add(shift);
            return _shiftRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
