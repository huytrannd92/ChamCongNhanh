namespace Schedule.Domain.AggregatesModel.CompanyAggregate
{
    public class Company : Entity, IAggregateRoot
    {
        private int _userId;



        public string CompanyName { get; private set; }
        public string CompanyAddress { get; private set; }


        private List<Employee> _employees;
        public IEnumerable<Employee> Employees => _employees.AsReadOnly();

        protected Company()
        {

            _employees = new List<Employee>();
        }


        public Company(int userId, string companyName, string address) : this()
        {
            _userId = userId;
            CompanyName = !string.IsNullOrWhiteSpace(companyName) ? companyName : throw new ArgumentNullException(nameof(companyName));
            CompanyAddress = !string.IsNullOrWhiteSpace(address) ? address : throw new ArgumentNullException(nameof(address));
        }
        public void AddEmployee(string name, string email, int userId, string phoneNumber)
        {
            var existingEmployee = _employees.FirstOrDefault(x => x.UserId == userId);
            if (existingEmployee != null) return;
            _employees.Add(new Employee(Id, userId, name, email, phoneNumber));

        }
        public void RemoveEmployee(int employeeId)
        {
            _employees.RemoveAll(i => i.Id == employeeId);
        }


    }
}
