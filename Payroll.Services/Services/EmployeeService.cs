using ExpressMapper;
using ExpressMapper.Extensions;
using Payroll.Domain.Entities;
using Payroll.Domain.Repositories;
using Payroll.Services.Contracts;
using Payroll.Services.Dtos.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> AddEmployeeAsync(CreateEmployeeDto employee)
        {
            var newEmployee = Mapper.Map<CreateEmployeeDto, Employee>(employee);
            var result = await _employeeRepository.AddAsync(newEmployee);
            return result;
        }

        public async Task<Employee> UpdateEmployeeAsync(UpdateEmployeeDto employee)
        {
            var updateEmployee = Mapper.Map<UpdateEmployeeDto, Employee>(employee);
            var result = await _employeeRepository.UpdateAsync(updateEmployee);
            return result;
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }
        
        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

       

      
    }
}

