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
        public DateTime StartHour { get; set; }
        [DataMember]
        public DateTime EndHour { get; set; }
    }
}
