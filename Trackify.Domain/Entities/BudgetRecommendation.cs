using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Domain.Entities
{
    public class BudgetRecommendation
    {
        [Key]
        public int RecommendationId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public double MinPercent { get; set; }
        public double MaxPercent { get; set; }
        public ICollection<BudgetCategory> BudgetCategories { get; set; } = new List<BudgetCategory>();
    }
}
