using web.Models;

namespace web.Services
{
    public interface IEmployeeService
    {
        List<Employees> GetEmployees();
    }
}