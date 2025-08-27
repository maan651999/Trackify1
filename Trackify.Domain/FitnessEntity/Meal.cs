using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackify.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trackify.Domain.FitnessEntity
{
    public class Meal
    {
        [Key]
        public int DietId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime MealTime { get; set; }
        [Required]
        public string MealType { get; set; } = "Breakfast"; // Breakfast/Lunch/Dinner/Snack
        [Required]
        public string FoodItem { get; set; } = string.Empty;
        [Required]
        public decimal Protein { get; set; }
        [Required]
        public decimal Carbs { get; set; }
        [Required]
        public decimal Calories { get; set; }
        [Required]
        public decimal Fats { get; set; }
        public User? User { get; set; }
    }
}
