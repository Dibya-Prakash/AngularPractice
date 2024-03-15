using Employee.API.Data;
using Employee.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.Controllers
{
    [ApiController] //To tell .net this is an api controller and this wont be having any views
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeesController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees=await _employeeDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employees employeeRequest)
        {
            employeeRequest.Id=Guid.NewGuid();
            await _employeeDbContext.Employees.AddAsync(employeeRequest);
            await _employeeDbContext.SaveChangesAsync();
            return Ok(employeeRequest);
        }
    }
}
