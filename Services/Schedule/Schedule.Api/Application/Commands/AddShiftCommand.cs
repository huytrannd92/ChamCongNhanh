using MediatR;
using System.Runtime.Serialization;

namespace Schedule.Api.Application.Commands
{
    [DataContract]
    public class AddShiftCommand : IRequest<bool>
    {
        [DataMember]
        public int CalendarId { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        private DateTime StartHour { get; set; }
        [DataMember]
        private DateTime EndHour { get; set; }
    }
}
