using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Dtos.Employees
{
    public sealed record UpdateEmployeeDto
    {
        public  Guid Id { get; init; }
        public string TC { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
    }
}
   
    


