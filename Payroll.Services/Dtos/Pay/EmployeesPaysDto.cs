using Payroll.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Dtos.Pay
{
    public class EmployeesPaysDto
    {
        public Guid Id { get; set; }
        public string TC { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public SalaryType SalaryType { get; set; }
        public DateTime Date { get; set; }
    }
}
