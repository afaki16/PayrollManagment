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
    public class CreatePayDto
    {
       
        public SalaryType SalaryType { get; set; }

        public decimal Salary { get; set; }
       
        public Guid EmployeeId { get; set; }
       
        public DateTime Date { get; set; }

        public List<CreatePayDetailDto> PayDetails { get; set; }
    }
}
