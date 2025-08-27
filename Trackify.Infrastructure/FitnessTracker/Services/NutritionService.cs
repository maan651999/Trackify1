using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackify.Application.Interfaces;

namespace Trackify.Infrastructure.FitnessTracker.Services
{
    public class NutritionService: INutritionRepository
    {
        private readonly AppDbContext _db;
        public NutritionService(AppDbContext db) => _db = db;

        public async Task<(decimal protein, decimal carbs, decimal fats, decimal calories)> GetDailyTotalsAsync(int userId, DateTime date)
        {
            var meals = await _db.Meals.Where(m => m.UserId == userId && m.MealTime == date.Date).ToListAsync();
            return (meals.Sum(m => m.Protein), meals.Sum(m => m.Carbs), meals.Sum(m => m.Fats), meals.Sum(m => m.Calories));
        }
    }
}
