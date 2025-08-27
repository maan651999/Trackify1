using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Trackify.Domain.FitnessEntity;

    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Full Name")]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 to 15 digits.")]
        public string Phone { get; set; } = string.Empty;
        [Required (ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#^])[A-Za-z\d@$!%*?&#^]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long, include uppercase, lowercase, number, and special character.")]
        public string PasswordHash { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public decimal Height { get; set; }
        [StringLength(100)]
        public string Goal { get; set; } = string.Empty;
        [StringLength(200)]
        public string PhotoUrl { get; set; } = "/images/default.png";
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastLoginIP { get; set; } = string.Empty;
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<MonthlyBudget> MonthlyBudgets { get; set; } = new List<MonthlyBudget>();
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<BudgetCategory> BudgetCategories { get; set; } = new List<BudgetCategory>();
        public ICollection<Meal> Meal { get; set; } = new List<Meal>();
        public ICollection<Progress> Progress { get; set; } = new List<Progress>();
        public ICollection<Workout> Workout { get; set; } = new List<Workout>();
    }
}
