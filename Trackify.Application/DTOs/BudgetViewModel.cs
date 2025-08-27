using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Application.DTOs
{
    public class BudgetViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal Remaining { get; set; }
    }
}
