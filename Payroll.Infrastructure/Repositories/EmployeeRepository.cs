using Microsoft.EntityFrameworkCore;
using Payroll.Domain.Entities;
using Payroll.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PayrollDbContext _context;

        public EmployeeRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddAsync(Employee entity)
        {
            var result = await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Employee not found");
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            var updateEmployee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == entity.Id);
            if (updateEmployee != null)
            {
                updateEmployee.TC = entity.TC;
                updateEmployee.Surname = entity.Surname;
                updateEmployee.Name = entity.Name;

                var result = _context.Employees.Update(entity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            else
            {
                throw new KeyNotFoundException("Employee not found");
            }
        }
    }

}
