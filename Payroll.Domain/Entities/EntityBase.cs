using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain.Entities
{
    public class EntityBase
    {
        public DateTime? DeletedDate { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; }

        public void Remove(string userId)
        {
            IsDeleted = true;
            DeletedBy = userId;
            DeletedDate = DateTime.UtcNow;
        }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
