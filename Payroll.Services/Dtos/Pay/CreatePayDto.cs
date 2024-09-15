using Payroll.Domain.Entities;
using Payroll.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.Services.Dtos.PayDetail;

namespace Payroll.Services.Dtos.Pay
{
    public sealed record CreatePayDto
    {
       
        public SalaryType SalaryType { get; init; }

        public decimal Salary { get; init; }
       
        public Guid EmployeeId { get; init; }
       
        public DateTime Date { get; init; }

        public List<CreatePayDetailDto> PayDetails { get; init; }
    }
}
