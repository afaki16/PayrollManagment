using Payroll.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Dtos.PayDetail
{
    public sealed record CreatePayDetailDto
    {
        public decimal Count { get; init; }

        public decimal Price { get; init; }
      
    }
}
