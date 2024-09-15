using Payroll.Domain.Entities;
using Payroll.Services.Dtos.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<Employee> AddEmployeeAsync(CreateEmployeeDto employee);
        Task<Employee> UpdateEmployeeAsync(UpdateEmployeeDto employee);
        Task DeleteEmployeeAsync(Guid id);
    }
}
