using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackify.Application.DTOs;
using Trackify.Domain.Entities;

namespace Trackify.Application.Interfaces
{
    public interface IBudgetService
    {
        Task<List<BudgetReportDto>> GetBudgetReportAsync(int userId);
        Task<List<BudgetCategoryDto>> GetAllAsync(int userId);
        Task<BudgetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(int userId, BudgetCategoryDto dto);
        Task UpdateAsync(BudgetCategoryDto dto);
        Task DeleteAsync(int id);
        Task<List<BudgetSuggestionDto>> GetBudgetSuggestionsAsync(int userId);
        List<RecommendedBudgetDto> GetRecommendedBudget(double monthlyIncome);
        Task<List<BudgetCategory>> GetBudgetCategoriesAsync(int userId);
    }
}
