// ServiceLayer Interface
public interface IEmployeeService
{
    IEnumerable<Employee> GetEmployees();
    Employee GetEmployeeById(int id);
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(int id);
}

// ServiceLayer Implementation
public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeDAL _employeeDAL;

    public EmployeeService(IEmployeeDAL employeeDAL)
    {
        _employeeDAL = employeeDAL;
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _employeeDAL.GetEmployees();
    }

    public Employee GetEmployeeById(int id)
    {
        return _employeeDAL.GetEmployeeById(id);
    }

    public void AddEmployee(Employee employee)
    {
        _employeeDAL.AddEmployee(employee);
    }

    public void UpdateEmployee(Employee employee)
    {
        _employeeDAL.UpdateEmployee(employee);
    }

    public void DeleteEmployee(int id)
    {
        _employeeDAL.DeleteEmployee(id);
    }
}
