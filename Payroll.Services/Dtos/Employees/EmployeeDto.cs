using Payroll.Domain.Enums;
using Payroll.Services.Dtos.Pay;
using Payroll.Services.Dtos.PayDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Dtos.Employees
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string TC { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<PayDto> Pays { get; set; }
    }
}

