using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Application.DTOs
{
    public class ExpenseDto
    {
        public int ExpenseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryId { get; set; }= string.Empty;
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(250)]
        public string? Notes { get; set; }
         public int Quantity { get; set; } = 1;
    }
}
