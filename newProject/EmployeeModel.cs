//Employee Model
public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

// DataAccessLayer Interface
public interface IEmployeeDAL
{
    IEnumerable<Employee> GetEmployees();
    Employee GetEmployeeById(int id);
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(int id);
}

// DataAccessLayer Implementation
public class EmployeeDAL : IEmployeeDAL
{
    private List<Employee> employees = new List<Employee>();

    public IEnumerable<Employee> GetEmployees()
    {
        return employees;
    }

    public Employee GetEmployeeById(int id)
    {
        return employees.FirstOrDefault(e => e.EmployeeId == id);
    }

    public void AddEmployee(Employee employee)
    {
        // Implement logic to add employee
        employees.Add(employee);
    }

    public void UpdateEmployee(Employee employee)
    {
        // Implement logic to update employee
    }

    public void DeleteEmployee(int id)
    {
        // Implement logic to delete employee
    }
}
