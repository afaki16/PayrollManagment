﻿using Microsoft.EntityFrameworkCore;
using Payroll.Domain.Entities;
using Payroll.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pay>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pay> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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
    }
}
