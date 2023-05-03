using MediatR;

namespace Schedule.Api.Application.Commands
{
    public class CreateCompanyCommand : IRequest<bool>
    {
        public string CompanyName { get; private set; }
        public string CompanyAddress { get; private set; }

    }
}
