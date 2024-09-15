using Payroll.Domain.Enums;
using Payroll.Services.Dtos.PayDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Dtos.Pay
{
    public sealed record UpdatePayDto
    {
        public int Id { get; init; }
        public SalaryType SalaryType { get; init; }

        public decimal Salary { get; init; }

        public Guid EmployeeId { get; init; }

        public DateTime Date { get; init; }

        public List<CreatePayDetailDto> PayDetails { get; init; }
    }
}
