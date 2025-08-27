using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Application.DTOs
{
    public class BudgetDto
    {
        [Required]
        public int IncomeId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
        [Required]
        public string Source { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }
    }
}
