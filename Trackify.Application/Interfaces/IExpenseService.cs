using Trackify.Application.DTOs;

namespace Trackify.Application.Interfaces
{
    public interface IExpenseService
    {
        Task AddExpenseAsync(ExpenseDto expense);
        Task<IEnumerable<ExpenseDto>> GetExpensesByMonthAsync(int userId, int year);
        Task<ExpenseDto> GetExpenseByIdAsync(int id);
        Task UpdateExpenseAsync(ExpenseDto expense);
        Task DeleteExpenseAsync(int id);
    }
}
