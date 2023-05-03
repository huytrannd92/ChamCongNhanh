using MediatR;
using Schedule.Api.Infrastructure.Providers;
using Schedule.Api.Infrastructure.Services;
using Schedule.Domain.AggregatesModel.CompanyAggregate;

namespace Schedule.Api.Application.Commands
{
    public class AssignEmployeeCommandHandler : IRequestHandler<AssignEmployeeCommand, bool>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserInfoProvider _userInfoProvider;
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;
        private readonly ILogger<AssignEmployeeCommandHandler> _logger;

        public async Task<bool> Handle(AssignEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeDto = await _userInfoProvider.GetUserInfoAsync(request.EmployeeEmail, request.EmployeePhoneNumber);

            var company = await _companyRepository.GetAsync(request.CompanyId);

            if (company == null || employeeDto == null)return false;

            company.AddEmployee(employeeDto.EmployeeName, employeeDto.Email, employeeDto.UserId, employeeDto.PhoneNumber);
            return await _companyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
