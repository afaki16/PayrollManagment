using Microsoft.EntityFrameworkCore;
using Payroll.Domain.Entities;
using Payroll.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Infrastructure.Repositories
{
    public class PayRepository : IPayRepository
    {
        private readonly PayrollDbContext _context;

        public PayRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<Pay> AddAsync(Pay entity)
        {
            var result = await _context.Pays.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Pay> UpdateAsync(Pay entity)
        {
            var updatePay = await _context.Pays.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (updatePay != null)
            {
                updatePay.Salary = entity.Salary;
                updatePay.SalaryType = entity.SalaryType;
                updatePay.Date = entity.Date;
                updatePay.EmployeeId = entity.EmployeeId;

                var result = _context.Pays.Update(entity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            else
            {
                throw new KeyNotFoundException("Pay not found");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var pay = await _context.Pays.FindAsync(id);
            if (pay != null)
            {
                _context.Pays.Remove(pay);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Employee not found");
            }

        }
        public async Task<IEnumerable<Pay>> GetAllAsync()
        {
            return await _context.Pays.ToListAsync();
        }

        public async Task<Pay> GetByIdAsync(int id)
        {
            var pay = await _context.Pays.FindAsync(id);
            if (pay == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }
            return pay;
        }

        public async Task<IEnumerable<Pay>> GetAllEmployeePays()
        {
            return await _context.Pays.Include(x => x.Employee).ToListAsync();
        }

       

        
    }
}
