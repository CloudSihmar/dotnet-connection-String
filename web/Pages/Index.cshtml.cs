using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web.Models;
using web.Services;

namespace web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public List<Employees> Employees;
       

        public void OnGet()
        {
       
            Employees = _employeeService.GetEmployees();

        }

    }
}
