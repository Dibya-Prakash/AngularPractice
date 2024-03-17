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

        [HttpGet]
        [Route("edit/{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("edit/{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employees updateEmployeeRequest)
        {
            var employee = await _employeeDbContext.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Department= updateEmployeeRequest.Department;

            await _employeeDbContext.SaveChangesAsync();

            return Ok(employee);

        }

    }
}
