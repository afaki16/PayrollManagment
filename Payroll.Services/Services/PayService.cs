using ExpressMapper;
using Payroll.Domain.Entities;
using Payroll.Domain.Enums;
using Payroll.Domain.Repositories;
using Payroll.Services.Contracts;
using Payroll.Services.Dtos.Employees;
using Payroll.Services.Dtos.Pay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Services
{
    public class PayService : IPayService
    {
        private readonly IPayRepository _payRepository;
        public PayService(IPayRepository payRepository)
        {
            _payRepository = payRepository;
        }

        public async Task<PayDto> AddPayAsync(CreatePayDto pay)
        {

            var newPay = Mapper.Map<CreatePayDto, Pay>(pay);
            var result = await _payRepository.AddAsync(newPay);
            return Mapper.Map<Pay, PayDto>(result); 

        }

        public async Task<PayDto> UpdatePayAsync(UpdatePayDto pay)
        {
            var updatePay = Mapper.Map<UpdatePayDto, Pay>(pay);
            var result = await _payRepository.UpdateAsync(updatePay);
            return Mapper.Map<Pay, PayDto>(result);
        }

        public decimal CalculateSalaray(List<Pay> listPay)
        {

            return listPay.Where(x => x.SalaryType == SalaryType.FixedSalary).Sum(x => x.Salary)
                + listPay.Where(x => x.SalaryType == SalaryType.DailyWage).Sum(x => x.Salary = x.PayDetails.Sum(y => y.Price * y.Count));
        }

        public Task DeletePayAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllPayAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pay> GetPayByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
