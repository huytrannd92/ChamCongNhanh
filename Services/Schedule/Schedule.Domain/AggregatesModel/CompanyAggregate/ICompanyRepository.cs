namespace Schedule.Domain.AggregatesModel.CompanyAggregate
{
    interface ICompanyRepository : IRepository<Company>
    {
        Company Add(Company shift);
    }
}
