using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackify.Application.DTOs;
using Trackify.Application.Interfaces;
using Trackify.Domain.Entities;

namespace Trackify.Infrastructure.Repositories
{
    public class BudgetService : IBudgetService
    {
        private readonly AppDbContext _context;
        public BudgetService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<BudgetReportDto>> GetBudgetReportAsync(int userId)
        {
            try
            {
                var categories = await _context.BudgetCategories
                .Where(c => c.UserId == userId)
                .ToListAsync();
                //Id

                var expenses = await _context.Expenses
                    .Where(e => e.UserId == userId)
                    .ToListAsync();

                //Category

                var report = categories.Select(cat =>
                {
                    var totalSpent = expenses
                        .Where(e => Convert.ToInt32(e.CategoryId) == cat.CategoryId)
                        .Sum(e => e.Amount);

                    return new BudgetReportDto
                    {
                        Category = cat.CategoryName,
                        BudgetAmount = cat.BudgetAmount,
                        SpentAmount = totalSpent,
                        UtilizationPercent = cat.BudgetAmount == 0 ? 0 :
                            Math.Round((double)(totalSpent / cat.BudgetAmount) * 100, 2),
                        IsOverBudget = totalSpent > cat.BudgetAmount
                    };
                }).ToList();

                return report;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<BudgetCategoryDto>> GetAllAsync(int userId)
        {
            try
            {
                return await _context.BudgetCategories
                .Where(x => x.UserId == userId)
                .Select(x => new BudgetCategoryDto
                {
                    RecommendationId = x.RecommendationId,
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    BudgetAmount = x.BudgetAmount
                })
                .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<BudgetCategoryDto> GetByIdAsync(int id)
        {
            try
            {
                var cat = await _context.BudgetCategories.FindAsync(id);
                return new BudgetCategoryDto
                {
                    CategoryId = cat.CategoryId,
                    CategoryName = cat.CategoryName,
                    BudgetAmount = cat.BudgetAmount
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task CreateAsync(int userId, BudgetCategoryDto dto)
        {
            try
            {
                var CategoryName = await _context.BudgetRecommendations.Where(x => x.RecommendationId == dto.CategoryId).Select(x => x.CategoryName).FirstOrDefaultAsync();
                var entity = new BudgetCategory
                {
                    UserId = userId,
                    RecommendationId = dto.CategoryId,
                    CategoryName = CategoryName,
                    BudgetAmount = dto.BudgetAmount
                };
                _context.BudgetCategories.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task UpdateAsync(BudgetCategoryDto dto)
        {
            try
            {
                var entity = await _context.BudgetCategories.FindAsync(dto.CategoryId);
                if (entity == null) return;

                entity.CategoryName = dto.CategoryName;
                entity.BudgetAmount = dto.BudgetAmount;

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.BudgetCategories.FindAsync(id);
                if (entity != null)
                {
                    _context.BudgetCategories.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<BudgetSuggestionDto>> GetBudgetSuggestionsAsync(int userId)
        {
            try
            {
                var now = DateTime.Now;
                var fromDate = new DateTime(now.Year, now.Month, 1).AddMonths(-3);

                // Get last 3 months expenses
                var expenses = await _context.Expenses
                    .Where(e => e.UserId == userId && e.Date >= fromDate)
                    .ToListAsync();

                // Current budget categories
                var budgets = await _context.BudgetCategories
                    .Where(b => b.UserId == userId)
                    .ToListAsync();

                var suggestions = budgets.Select(b =>
                {
                    var categoryExpenses = expenses
                        .Where(e => e.CategoryId.ToString() == b.CategoryName)
                        .GroupBy(e => new { e.Date.Year, e.Date.Month })
                        .Select(g => g.Sum(e => e.Amount));

                    var averageSpent = categoryExpenses.Any() ? categoryExpenses.Average() : 0;

                    decimal suggestedBudget = b.BudgetAmount;

                    if (averageSpent < b.BudgetAmount * 0.7M)
                    {
                        suggestedBudget = Math.Round(averageSpent + 500, 0); // Suggest reduce
                    }
                    else if (averageSpent > b.BudgetAmount * 0.9M)
                    {
                        suggestedBudget = Math.Round(averageSpent + 500, 0); // Suggest increase
                    }

                    return new BudgetSuggestionDto
                    {
                        Category = b.CategoryName,
                        CurrentBudget = b.BudgetAmount,
                        AverageSpent = Math.Round((decimal)averageSpent, 2),
                        SuggestedBudget = suggestedBudget
                    };
                }).ToList();

                return suggestions;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<RecommendedBudgetDto> GetRecommendedBudget(double monthlyIncome)
        {
            try
            {
                return _context.BudgetRecommendations.Select(r => new RecommendedBudgetDto
                {
                    RecommendationId = r.RecommendationId,
                    CategoryName = r.CategoryName,
                    IdealMinAmount = Math.Round(monthlyIncome * r.MinPercent / 100, 2),
                    IdealMaxAmount = Math.Round(monthlyIncome * r.MaxPercent / 100, 2),
                     IdealAvgAmount = Math.Round(
                ((monthlyIncome * r.MinPercent / 100) + (monthlyIncome * r.MaxPercent / 100)) / 2, 2
            )
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<BudgetCategory>> GetBudgetCategoriesAsync(int userId)
        {
            try
            {
                var categories = await _context.BudgetCategories
              .Where(c => c.UserId == userId)
              .ToListAsync();
                return categories;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
