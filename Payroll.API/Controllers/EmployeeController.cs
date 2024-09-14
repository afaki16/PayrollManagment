using ExpressMapper;
using ExpressMapper.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payroll.Domain.Entities;
using Payroll.Infrastructure;
using Payroll.Services.Contracts;
using Payroll.Services.Dtos.Employees;
using Payroll.Services.Services;

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
      
            private readonly IEmployeeService _employeeService;

            public EmployeeController(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Employee>> GetEmployeeById(int id)
            {
                try
                {
                    var employee = await _employeeService.GetEmployeeByIdAsync(id);
                    return Ok(employee);
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }

            [HttpPost]
            public async Task<ActionResult> AddEmployee(CreateEmployeeDto employee)
            {
               var result = await _employeeService.AddEmployeeAsync(employee);
                 
                return Ok(result);
            }

            [HttpPut()]
            public async Task<ActionResult> UpdateEmployee(UpdateEmployeeDto employee)
            {
                try
                {
                    await _employeeService.UpdateEmployeeAsync(employee);
                    return NoContent();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteEmployee(int id)
            {
                try
                {
                    await _employeeService.DeleteEmployeeAsync(id);
                    return NoContent();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }
        }
    }

