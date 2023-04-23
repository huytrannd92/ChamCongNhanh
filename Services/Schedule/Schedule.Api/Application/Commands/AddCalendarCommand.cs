using MediatR;
using System.Runtime.Serialization;

namespace Schedule.Api.Application.Commands
{
    public class AddCalendarCommand : IRequest<bool>
    {
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int Month { get; set; }
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public IEnumerable<ShiftConfigDTO> ShiftConfigs {set; get;}
    }

    public record ShiftConfigDTO
    {
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
    }
}
