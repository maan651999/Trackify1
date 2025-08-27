using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Application.DTOs
{
    public class BudgetReportDto
    {
        public string Category { get; set; } = string.Empty;
        public decimal BudgetAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public double UtilizationPercent { get; set; }
        public bool IsOverBudget { get; set; }
    }
}
