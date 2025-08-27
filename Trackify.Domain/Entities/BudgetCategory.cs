using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Domain.Entities
{
    public class BudgetCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public int RecommendationId { get; set; }
        public int UserId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal BudgetAmount { get; set; }
        public User? User { get; set; }
        public BudgetRecommendation? BudgetRecommendation { get; set; }
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
