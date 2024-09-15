using Payroll.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Dtos.Pay
{
    public sealed record EmployeesPaysDto
    {
        public Guid Id { get; init; }
        public string TC { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public decimal Salary { get; init; }
        public SalaryType SalaryType { get; init; }
        public DateTime Date { get; init; }
    }
}
