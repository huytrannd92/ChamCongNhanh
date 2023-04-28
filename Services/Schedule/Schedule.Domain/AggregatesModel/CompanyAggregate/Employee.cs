namespace Schedule.Domain.AggregatesModel.CompanyAggregate
{
    public class Employee :Entity 
    {
        public int CompanyId { get; set; }

        public int UserId { get; set; }

        public string EmployeeName { get; set; }
        public string Email { get; set; }

        public Employee(int companyId, int userId, string name, string email)
        {
            CompanyId = companyId;
            UserId = userId;
            EmployeeName = name;    
            Email = email;  
        }
    }
}
