using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Application.DTOs
{
    public class BudgetSuggestionDto
    {
        public string Category { get; set; } = string.Empty;
        public decimal CurrentBudget { get; set; }
        public decimal AverageSpent { get; set; }
        public decimal SuggestedBudget { get; set; }
    }
}
