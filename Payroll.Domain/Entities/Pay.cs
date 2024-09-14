using Payroll.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain.Entities
{
    public class Pay : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public SalaryType SalaryType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<PayDetail> PayDetails { get; set; }
    }
}
