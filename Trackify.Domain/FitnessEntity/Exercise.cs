using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Domain.FitnessEntity
{
    public class Exercise
    {
        public int Id { get; set; }
        public int WorkoutDayId { get; set; }
        public Workout? WorkoutDay { get; set; }

        public string Name { get; set; } = string.Empty;
        public int Sets { get; set; }
        public string Reps { get; set; } = "12"; // e.g., "12", "12-15", "AMRAP"
        public string? Notes { get; set; }
        public bool Completed { get; set; } = false;
    }
}
