using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Application.DTOs
{
    public class RecommendedBudgetDto
    {
        public int RecommendationId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public double IdealMinAmount { get; set; }
        public double IdealMaxAmount { get; set; }
        public double IdealAvgAmount { get; set; }
        public bool IsAdded { get; set; }
    }
}
