using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackify.Domain.Entities;

namespace Trackify.Application.Interfaces
{
    public interface IMonthlyBudgetRepository
    {
        //Monthly Budget
        Task<MonthlyBudget?> GetByUserAndMonthAsync(int userId, int year);  
        Task AddAsync(MonthlyBudget budget);
        Task UpdateAsync(MonthlyBudget budget);
        Task<List<BudgetRecommendation>> GetCategoriesAsync();
    }
}
