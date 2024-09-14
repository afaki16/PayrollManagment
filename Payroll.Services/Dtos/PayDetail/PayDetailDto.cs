using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Dtos.PayDetail
{
    public class PayDetailDto
    {
        public int Id { get; set; }
        public decimal Count { get; set; }
        public decimal Price { get; set; }
        public int PayId { get; set; }
    }
}
