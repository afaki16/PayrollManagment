using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.Domain.Enums;

namespace Payroll.Domain.Entities
{
    public class PayDetail
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Count { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int PayId { get; set; }

        [ForeignKey("PayId")]
        public virtual Pay Pay { get; set; }
    }
}
