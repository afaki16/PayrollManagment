using Payroll.Domain.Enums;
using Payroll.Services.Dtos.PayDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Dtos.Pay
{
    public class UpdatePayDto
    {
        public int Id { get; set; }
        public SalaryType SalaryType { get; set; }

        public decimal Salary { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public List<CreatePayDetailDto> PayDetails { get; set; }
    }
}
