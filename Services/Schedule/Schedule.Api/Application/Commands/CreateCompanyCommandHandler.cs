using MediatR;
using Schedule.Api.Infrastructure.Providers;
using Schedule.Api.Infrastructure.Services;
using Schedule.Domain.AggregatesModel.CompanyAggregate;

namespace Schedule.Api.Application.Commands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, bool>

    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IIdentityService _identityService;
        private readonly ILogger<CreateCompanyCommandHandler> _logger;


        public async Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company(int.Parse(_identityService.GetUserIdentity()), request.CompanyName, request.CompanyAddress);
            _companyRepository.Add(company);
            return await _companyRepository.UnitOfWork.SaveEntitiesAsync();

        }
    }
}
