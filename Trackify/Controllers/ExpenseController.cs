using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trackify.Application.DTOs;
using Trackify.Application.Interfaces;
using Trackify.Web.Filters;

namespace Trackify.Web.Controllers
{
    [SessionCheck]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IMonthlyBudgetRepository _budgetRepository;
        private readonly IBudgetService _budgetService;
        protected int UserId => Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        private ISession Session => HttpContext.Session;
        public ExpenseController(IMonthlyBudgetRepository budgetRepository, IExpenseService expenseService, IBudgetService budgetService)
        {
            _budgetRepository = budgetRepository;
            _expenseService = expenseService;
            _budgetService = budgetService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var expenses = await _expenseService.GetExpensesByMonthAsync(UserId, DateTime.Now.Year);
                var expenseCategoryIds = expenses.Select(e => e.CategoryId).Distinct().ToList();

                var budget = _budgetService.GetBudgetCategoriesAsync(UserId).Result;
                var sortedBudget = budget.Where(b => !expenseCategoryIds.Contains(b.CategoryId.ToString())).OrderBy(b => b.CategoryName).ToList();

                ViewBag.CategoryList = new SelectList(sortedBudget, "CategoryId", "CategoryName");
                return View(new ExpenseDto { Date = DateTime.Today });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(ExpenseDto model)
        {
            try
            {
                model.UserId = UserId;
                model.Quantity = 1;

                if (ModelState.IsValid)
                {
                    await _expenseService.AddExpenseAsync(model);
                    return RedirectToAction("Monthly");
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Monthly()
        {
            try
            {
                int month = 0;
                int year = 0;

                if (month == 0) month = DateTime.Now.Month;
                if (year == 0) year = DateTime.Now.Year;

                var data = await _expenseService.GetExpensesByMonthAsync(UserId, year);
                var budget = await _budgetRepository.GetByUserAndMonthAsync(UserId, year);
                ViewBag.Month = month;
                ViewBag.Year = year;
                ViewBag.Date = DateTime.Now;
                if (budget != null && data.FirstOrDefault() != null)
                {
                    ViewBag.Budget = budget.Amount;
                    ViewBag.Total = data.Sum(e => e.Amount);
                }
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IncreaseQuantity(int id)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                TempData["ErrorMessage"] = "Expense not found!";
                return RedirectToAction("Index");
            }

            expense.Quantity += 1;   // ✅ Increase by 1
            expense.Amount += expense.Amount;   // ✅ Increase Amount
            await _expenseService.UpdateExpenseAsync(expense);

            TempData["SuccessMessage"] = $"Quantity increased (₹{expense.Amount})";
            return RedirectToAction("Monthly");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var budget = _budgetService.GetBudgetCategoriesAsync(UserId).Result;
                ViewBag.CategoryList = new SelectList(budget, "CategoryId", "CategoryName");

                var expense = await _expenseService.GetExpenseByIdAsync(id);
                return View(expense);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ExpenseDto model)
        {
            try
            {
                model.UserId = UserId;
                if (ModelState.IsValid)
                {
                    await _expenseService.UpdateExpenseAsync(model);
                    return RedirectToAction("Monthly");
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _expenseService.DeleteExpenseAsync(id);
                TempData["SuccessMessage"] = "Expences deleted successfully.";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Unable to delete the Expences. It may be linked to existing category.";
            }
            return RedirectToAction("Monthly");
        }
    }
}
