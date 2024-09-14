using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain.Enums
{
    public enum SalaryType
    {
        [Description("Sabit Maaş")]
         FixedSalary = 0,
        [Description("Günlük Maaş")]
        DailyWage = 1,
        [Description("Fazla Mesai")]
        Overtime = 2,


    }
}
