using Payroll.Domain.Entities;
using Payroll.Services.Dtos.Pay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Contracts
{
    public interface IPayService
    {
        Task<IEnumerable<Employee>> GetAllPayAsync();
        Task<Pay> GetPayByIdAsync(int id);
        Task<PayDto> AddPayAsync(CreatePayDto pay);
        Task<PayDto> UpdatePayAsync(UpdatePayDto pay);
        Task DeletePayAsync(int id);
    }
}
