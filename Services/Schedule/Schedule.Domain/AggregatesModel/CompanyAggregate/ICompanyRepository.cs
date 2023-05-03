using System;

namespace Schedule.Domain.AggregatesModel.CompanyAggregate
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company Add(Company company);
        Company Update(Company company);

        Task<Company> GetAsync(int companyId);



    }
}
