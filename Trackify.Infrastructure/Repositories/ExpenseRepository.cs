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
    public class ExpenseRepository : IExpenseService
    {
        private readonly AppDbContext _context;
        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddExpenseAsync(ExpenseDto expense)
        {
            try
            {
                var entity = new Expense
                {
                    UserId = expense.UserId,
                    Amount = expense.Amount,
                    CategoryId = Convert.ToInt32(expense.CategoryId),
                    Date = expense.Date,
                    Notes = expense.Notes
                };
                _context.Expenses.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<ExpenseDto>> GetExpensesByMonthAsync(int userId, int year)
        {
            try
            {
                var result = await _context.Expenses
                .Where(e => e.UserId == userId && e.Date.Year == year)
                .Select(e => new ExpenseDto
                {
                    ExpenseId = e.ExpenseId,
                    UserId = e.UserId,
                    Amount = e.Amount,
                    CategoryId = e.CategoryId.ToString(),
                    Date = e.Date,
                    Notes = e.Notes,
                    Quantity = e.Quantity,
                })
                .ToListAsync();

                var categoryIds = result.Select(x => x.CategoryId).Distinct().ToList();   

                var budgetCategories = await _context.BudgetCategories.Where(x => categoryIds.Any()).ToListAsync();

                // 🔁 Assign matched BudgetCategory data to each ExpenseDto
                foreach (var expense in result)
                {
                    var matchedCategory = budgetCategories.FirstOrDefault(b => b.CategoryId == Convert.ToInt32(expense.CategoryId));
                    if (matchedCategory != null)
                    {
                        expense.CategoryName = matchedCategory.CategoryName;
                    }
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ExpenseDto> GetExpenseByIdAsync(int id)
        {
            try
            {
                var entity = await _context.Expenses.Where(x => x.ExpenseId == id).FirstOrDefaultAsync();
                if (entity == null) 
                    return null;

                return new ExpenseDto
                {
                    ExpenseId = entity.ExpenseId,
                    UserId = entity.UserId,
                    Amount = entity.Amount,
                    CategoryId = entity.CategoryId.ToString(),
                    Date = entity.Date,
                    Notes = entity.Notes,
                    Quantity = entity.Quantity,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task UpdateExpenseAsync(ExpenseDto expense)
        {
            try
            {
                var entity = await _context.Expenses.FindAsync(expense.ExpenseId);
                if (entity != null)
                {
                    entity.Amount = expense.Amount;
                    entity.CategoryId = Convert.ToInt32(expense.CategoryId);
                    entity.Date = expense.Date;
                    entity.Notes = expense.Notes;
                    entity.Quantity = expense.Quantity;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteExpenseAsync(int id)
        {
            try
            {
                var entity = await _context.Expenses.FindAsync(id);
                if (entity != null)
                {
                    _context.Expenses.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
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
        public async Task<MonthlyBudget?> GetAsync(int userId, int year, int month)
        {
            try
            {
                var result = await _context.MonthlyBudgets
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.UserId == userId && b.Year == year && b.Month == month);
                if (result == null)
                   return null;

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task SetAsync(MonthlyBudget budget)
        {
            try
            {
                var existing = await _context.MonthlyBudgets
                .FirstOrDefaultAsync(b => b.UserId == budget.UserId && b.Year == budget.Year && b.Month == budget.Month);

                if (existing == null)
                {
                    await _context.MonthlyBudgets.AddAsync(budget);
                }
                else
                {
                    existing.Amount = budget.Amount;
                    _context.MonthlyBudgets.Update(existing);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
