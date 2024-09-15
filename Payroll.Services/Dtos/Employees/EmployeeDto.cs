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
    public sealed record EmployeeDto
    {
        public Guid Id { get; init; }
        public string TC { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public List<PayDto> Pays { get; init; }
    }
}

