using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web.Models;
using web.Services;

namespace web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Employees> Employees;

        public void OnGet()
        {
            EmployeeService employeesService = new EmployeeService();
            Employees = employeesService.GetEmployees();

        }

    }
}
