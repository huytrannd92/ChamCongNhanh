using MediatR;

namespace Schedule.Api.Application.Commands
{
    public class AssignEmployeeCommand :IRequest<bool>
    {
        public int CompanyId { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhoneNumber { get; set; }
    }
}
