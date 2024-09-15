using Payroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain.Repositories
{
    public interface IPayRepository :IRepository<Pay>
    {
        Task DeleteAsync(int id);
        Task<Pay> GetByIdAsync(int id);
        Task<IEnumerable<Pay>> GetAllEmployeePays();
    }
}
