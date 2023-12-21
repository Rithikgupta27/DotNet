// Controller
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public ActionResult Index()
    {
        var employees = _employeeService.GetEmployees();
        return View(employees);
    }

    // Implement other actions (Create, Edit, Delete) as needed
}
