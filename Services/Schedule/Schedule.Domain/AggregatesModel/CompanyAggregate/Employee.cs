namespace Schedule.Domain.AggregatesModel.CompanyAggregate
{
    public class Employee : Entity
    {
        int _companyId { get; set; }

        int _userId { get; set; }

        string _employeeName { get; set; }
        string _email { get; set; }
        string _phoneNumber { get; set; }

        public int UserId
        {
            get { return _userId; }
        }


        public Employee(int companyId, int userId, string name, string email, string phoneNumber)
        {
            _companyId = companyId;
            _userId = userId;
            _employeeName = name;
            _email = email;
            _phoneNumber = phoneNumber;
        }
    }
}
