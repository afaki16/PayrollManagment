using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain.Entities
{
    public class Employee : EntityBase
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(11)]
        public string TC { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        public virtual ICollection<Pay> Pays { get; set; }
    }
}
