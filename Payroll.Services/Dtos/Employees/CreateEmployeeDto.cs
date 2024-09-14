using Payroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Dtos.Employees
{
    public sealed record CreateEmployeeDto
    {
        public string TC { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
    }
}
