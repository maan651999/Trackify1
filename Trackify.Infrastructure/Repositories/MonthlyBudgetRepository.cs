using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackify.Application.Interfaces;
using Trackify.Domain.Entities;

namespace Trackify.Infrastructure.Repositories
{
    public class MonthlyBudgetRepository : IMonthlyBudgetRepository
    {
        private readonly AppDbContext _context;
        public MonthlyBudgetRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<MonthlyBudget?> GetByUserAndMonthAsync(int userId, int year)
        {
            try
            {
                var result = await _context.MonthlyBudgets
                .FirstOrDefaultAsync(b => b.UserId == userId && b.Year == year);

                if (result == null) 
                    return null;

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        // ➕ Add Monthly Budget
        public async Task AddAsync(MonthlyBudget budget)
        {
            try
            {
                await _context.MonthlyBudgets.AddAsync(budget);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        // ✏️ Update Monthly Budget
        public async Task UpdateAsync(MonthlyBudget budget)
        {
            try
            {
                _context.MonthlyBudgets.Update(budget);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        } 
        public async Task<List<BudgetRecommendation>> GetCategoriesAsync()
        {
            try
            {
                var result = await _context.BudgetRecommendations.ToListAsync();
                if (result == null)
                    return null;

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
