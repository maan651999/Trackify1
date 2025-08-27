using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackify.Application.Interfaces;

namespace Trackify.Infrastructure.FitnessTracker.Services
{
    public class ReportService:IReport
    {
        private readonly AppDbContext _db;
        public ReportService(AppDbContext db) => _db = db;

        public async Task<(IEnumerable<(DateTime date, decimal protein)> protein, IEnumerable<(DateTime date, decimal calories)> calories)> GetWeeklyNutritionAsync(int userId, DateTime start)
        {
            var end = start.Date.AddDays(7);
            var meals = await _db.Meals.Where(m => m.UserId == userId && m.MealTime >= start && m.MealTime < end).ToListAsync();
            var protein = meals.GroupBy(m => m.MealTime).Select(g => (g.Key, g.Sum(x => x.Protein))).OrderBy(x => x.Key);
            var calories = meals.GroupBy(m => m.MealTime).Select(g => (g.Key, g.Sum(x => x.Calories))).OrderBy(x => x.Key);
            return (protein, calories);
        }
    }
}
