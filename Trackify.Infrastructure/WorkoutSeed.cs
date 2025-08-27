using Microsoft.EntityFrameworkCore;
using Trackify.Domain.FitnessEntity;

namespace Trackify.Infrastructure
{
    public static class WorkoutSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var userId = 3;
            int wdId = 1, exId = 1;

            var focuses = new (DayOfWeek day, string focus, string[] ex)[]
            {
            (DayOfWeek.Monday, "Chest + Triceps", new[]{"Bench Press:4x12","Incline DB Press:3x12","DB Fly:3x15","Triceps Pushdown:3x12","Overhead Extension:3x12"}),
            (DayOfWeek.Tuesday, "Back + Biceps", new[]{"Lat Pulldown:4x12","Barbell Row:3x12","Seated Row:3x12","Bicep Curl:3x12","Hammer Curl:3x12"}),
            (DayOfWeek.Wednesday, "Legs + Core", new[]{"Squats:4x12","Lunges:3x12","Leg Press:3x12","Leg Curl:3x15","Plank:3x45s"}),
            (DayOfWeek.Thursday, "Shoulders + Abs", new[]{"Shoulder Press:4x12","Lateral Raise:3x12","Front Raise:3x12","Shrugs:3x15","Mountain Climbers:3x30s"}),
            (DayOfWeek.Friday, "Full Body + HIIT", new[]{"Deadlifts:4x12","Push-Ups:3x15","Burpees:3x12","Battle Ropes:3x30s","HIIT Treadmill:15min"}),
            (DayOfWeek.Saturday, "Abs + Cardio", new[]{"Plank:3x60s","Side Plank:3x30s each","Russian Twist:3x15","Bicycle Crunch:3x15","Jogging:20min"}),
            (DayOfWeek.Sunday, "Rest/Recovery", new[]{"Walk + Stretch:20min"})
            };

            var workoutDays = new List<Workout>();
            var exercises = new List<Exercise>();

            for (int week = 1; week <= 8; week++)
            {
                foreach (var f in focuses)
                {
                    workoutDays.Add(new Workout
                    {
                        WorkoutId = wdId,
                        UserId = userId,
                        WeekNumber = week,
                        DayOfWeek = f.day,
                    });

                    foreach (var e in f.ex)
                    {
                        var parts = e.Split(':');
                        exercises.Add(new Exercise
                        {
                            Id = exId++,
                            WorkoutDayId = wdId,
                            Name = parts[0],
                            Sets = int.TryParse(parts.ElementAtOrDefault(1)?.Split('x')[0], out var s) ? s : 3,
                            Reps = parts.ElementAtOrDefault(1)?.Split('x').ElementAtOrDefault(1) ?? "12"
                        });
                    }

                    wdId++;
                }
            }

            modelBuilder.Entity<Workout>().HasData(workoutDays);
            modelBuilder.Entity<Exercise>().HasData(exercises);
        }
    }
}
