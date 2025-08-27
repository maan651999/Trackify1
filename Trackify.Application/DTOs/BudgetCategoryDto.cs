using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Application.DTOs
{
    public class BudgetCategoryDto
    {
        public int CategoryId { get; set; }
        public int RecommendationId { get; set; }
        public int UserId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal BudgetAmount { get; set; }
    }
}
