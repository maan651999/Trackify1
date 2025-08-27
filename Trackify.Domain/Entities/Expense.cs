using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Domain.Entities
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; } = string.Empty;
        public User? User { get; set; }
        public BudgetCategory? BudgetCategory { get; set; }
        public int Quantity { get; set; }
    }
}
