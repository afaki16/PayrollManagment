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

            if (employees == null || !employees.Any())
            {
                return NoContent(); 
            }

            return Ok(employees);
        }

            [HttpGet("{id}")]
            public async Task<ActionResult<Employee>> GetEmployeeById(Guid id)
            {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);

                if (employee == null)
                {
                    return NotFound(new { Message = $"Employee with ID {id} not found" }); 
                }

                return Ok(employee); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Employee with ID {id} not found" }); 
            }
        }

            [HttpPost]
            public async Task<ActionResult> AddEmployee(CreateEmployeeDto employee)
            {
                var result = await _employeeService.AddEmployeeAsync(employee);

            if (result != null)
            {
                return CreatedAtAction(nameof(GetEmployeeById), new { id = result.Id }, result); 
            }

            return BadRequest(new { Message = "Failed to add employee" });
            }

            [HttpPut()]
            public async Task<ActionResult> UpdateEmployee(UpdateEmployeeDto employee)
            {
            try
            {
                await _employeeService.UpdateEmployeeAsync(employee);
                return Ok(new { Message = "Employee updated successfully" }); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Employee with ID {employee.Id} not found" }); 
            }
        }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteEmployee(Guid id)
            {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return Ok(new { Message = $"Employee with ID {id} deleted successfully" }); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Employee with ID {id} not found" }); 
            }
        }
        }
    }

