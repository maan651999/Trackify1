using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackify.Domain.Entities;

namespace Trackify.Domain.FitnessEntity
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int WeekNumber { get; set; } // 1..8
        [Required]
        public DayOfWeek DayOfWeek { get; set; }
        [Required]
        [StringLength(50)]
        public string ExerciseName { get; set; } = string.Empty;
        [Required]
        public int Sets { get; set; }
        [Required]
        public int Reps { get; set; }
        public DateTime Focus { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Notes { get; set; } = string.Empty;
        public User? User { get; set; }
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
