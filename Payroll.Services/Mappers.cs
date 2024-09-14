using ExpressMapper;
using Payroll.Domain.Entities;
using Payroll.Services.Dtos.Employees;
using Payroll.Services.Dtos.Pay;
using Payroll.Services.Dtos.PayDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services
{
    public class Mappers
    {
        public static void RegisterMappings()
        {

            Mapper.Register<Employee, CreateEmployeeDto>();
            Mapper.Register<Employee, UpdateEmployeeDto>();



            Mapper.Register<Pay, CreatePayDto>();
            Mapper.Register<Pay, UpdatePayDto>();
            Mapper.Register<Pay, PayDto>();
            Mapper.Register<Pay, EmployeesPaysDto>();
            Mapper.Register<PayDetail, PayDetailDto>();
               
        }
    }
}
