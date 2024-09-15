using ExpressMapper;
using ExpressMapper.Extensions;
using Microsoft.EntityFrameworkCore;
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
        private readonly IEmployeeRepository _employeeRepository;
        public PayService(IPayRepository payRepository, IEmployeeRepository employeeRepository)
        {
            _payRepository = payRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<PayDto> AddPayAsync(CreatePayDto pay)
        {
            if(pay.SalaryType == SalaryType.Overtime)
            {
               pay.Salary += pay.PayDetails.FirstOrDefault().Count * pay.PayDetails.FirstOrDefault().Price;
            }
            else if(pay.SalaryType == SalaryType.DailyWage)
            {
                pay.Salary = pay.PayDetails.FirstOrDefault().Count * pay.PayDetails.FirstOrDefault().Price;
            }
            
            var newPay = Mapper.Map<CreatePayDto, Pay>(pay);
            var result = await _payRepository.AddAsync(newPay);
            return Mapper.Map<Pay, PayDto>(result); 

        }

        public async Task<PayDto> UpdatePayAsync(UpdatePayDto pay)
        {
            if (pay.SalaryType == SalaryType.Overtime)
            {
                pay.Salary += pay.PayDetails.FirstOrDefault().Count * pay.PayDetails.FirstOrDefault().Price;
            }
            else if (pay.SalaryType == SalaryType.DailyWage)
            {
                pay.Salary = pay.PayDetails.FirstOrDefault().Count * pay.PayDetails.FirstOrDefault().Price;
            }

            var updatePay = Mapper.Map<UpdatePayDto, Pay>(pay);
            var result = await _payRepository.UpdateAsync(updatePay);
            return Mapper.Map<Pay, PayDto>(result);
        }

        public async Task DeletePayAsync(int id)
        {
            await _payRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Pay>> GetAllPayAsync()
        {
            return await _payRepository.GetAllAsync();
        }

        public async Task<IEnumerable<EmployeesPaysDto>> GetAllEmployeePaysAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var pays = await _payRepository.GetAllAsync();

            var employeesPays = (from e in employees
                                 join p in pays on e.Id equals p.EmployeeId
                                 select new EmployeesPaysDto
                                 {
                                     Id = e.Id,
                                     TC = e.TC,
                                     Name = e.Name,
                                     Surname = e.Surname,
                                     Salary = p.Salary,
                                     SalaryType = p.SalaryType,
                                     Date = p.Date
                                 }).ToList();

            return employeesPays;
        }

        public async Task<Pay> GetPayByIdAsync(int id)
        {
            return await _payRepository.GetByIdAsync(id);
        }

        public decimal CalculateSalaray(List<Pay> listPay)
        {

            return listPay.Where(x => x.SalaryType == SalaryType.FixedSalary).Sum(x => x.Salary)
                + listPay.Where(x => x.SalaryType == SalaryType.DailyWage).Sum(x => x.Salary = x.PayDetails.Sum(y => y.Price * y.Count));
        }

       
    }
}
