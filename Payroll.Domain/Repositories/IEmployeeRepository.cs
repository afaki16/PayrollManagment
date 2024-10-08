﻿using Payroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task DeleteAsync(Guid id);
        Task<Employee> GetByIdAsync(Guid id);
    }
}
