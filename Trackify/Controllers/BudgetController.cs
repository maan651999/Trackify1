using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trackify.Application.DTOs;
using Trackify.Application.Interfaces;
using Trackify.Domain.Entities;
using Trackify.Web.Filters;

namespace Trackify.Web.Controllers
{
    [SessionCheck]
    public class BudgetController : Controller
    {
        private readonly IBudgetService _budgetService;
        private readonly IConverter _converter;
        private readonly IMonthlyBudgetRepository _budgetRepository;
        private readonly IExpenseService _expenseService;
        private ISession Session => HttpContext.Session;
        protected int UserId => Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        public BudgetController(IBudgetService budgetService, IConverter converter, IMonthlyBudgetRepository budgetRepository, IExpenseService expenseService)
        {
            _budgetService = budgetService;
            _converter = converter;
            _budgetRepository = budgetRepository;
            _expenseService = expenseService;
        }
        [HttpGet]
        public async Task<IActionResult> Report()
        {
            try
            {
                ;
                var report = await _budgetService.GetBudgetReportAsync(UserId);
                return View(report);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var categories = await _budgetService.GetAllAsync(UserId);
                return View(categories);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("/Budget/Create/{id}")]
        public IActionResult Create(int id, Double avgAmt)
        {
            try
            {
                var categories = _budgetRepository.GetCategoriesAsync();
                ViewBag.CategoryList = categories.Result.OrderBy(c => c.RecommendationId).Select(c => new SelectListItem
                {
                    Value = c.RecommendationId.ToString(),
                    Text = c.CategoryName,
                    Selected = c.RecommendationId == id
                }).ToList();

                ViewBag.DefaultBudgetAmount = avgAmt;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(BudgetCategoryDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var monthlyIncome = await _budgetRepository.GetByUserAndMonthAsync(UserId, DateTime.Now.Year);

                    if (monthlyIncome == null || monthlyIncome.Amount <= 0)
                    {
                        TempData["ErrorMessage"] = "Please set your monthly Budget before viewing recommendations.";
                        return RedirectToAction("SetBudget", "Budget");
                    }

                    var recommendations = _budgetService.GetRecommendedBudget(Convert.ToDouble(monthlyIncome.Amount));

                    // Update matching categories with recommended amounts
                    foreach (var recommendation in recommendations.Where(x => x.RecommendationId == dto.CategoryId))
                    {
                        var enteredAmount = Convert.ToDouble(dto.BudgetAmount);
                        if (enteredAmount < recommendation.IdealMinAmount)
                        {
                            TempData["ErrorMessage"] = $"⚠ The amount you entered (₹{enteredAmount}) for '{recommendation.CategoryName}' " +
                                                       $"is too low. Minimum suggested is ₹{recommendation.IdealMinAmount}.";
                            return RedirectToAction("Create");
                        }
                        else if (enteredAmount > recommendation.IdealMaxAmount)
                        {
                            TempData["ErrorMessage"] = $"⚠ The amount you entered (₹{enteredAmount}) for '{recommendation.CategoryName}' " +
                                                       $"is too high. Maximum suggested is ₹{recommendation.IdealMaxAmount}.";
                            return RedirectToAction("Create");
                        }
                    }

                    // Create

                    await _budgetService.CreateAsync(Convert.ToInt32(UserId), dto);
                    return RedirectToAction("BudgetAllocation");
                }
                return View(dto);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var category = await _budgetService.GetByIdAsync(id);
                return View(category);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BudgetCategoryDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _budgetService.UpdateAsync(dto);
                    return RedirectToAction("Index");
                }
                return View(dto);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _budgetService.DeleteAsync(id);
                TempData["SuccessMessage"] = "Category deleted successfully.";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Unable to delete the category. It may be linked to existing expenses.";
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Suggestions()
        {
            try
            {
                var suggestions = await _budgetService.GetBudgetSuggestionsAsync(Convert.ToInt32(UserId));
                return View(suggestions);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> ExportSuggestionsPdf()
        {
            try
            {
                var suggestions = await _budgetService.GetBudgetSuggestionsAsync(UserId);
                string html = await Trackify.Web.Filters.ControllerExtensions.RenderViewAsync(this, "SuggestionsPdf", suggestions, true);
                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
            PaperSize = PaperKind.A4,
            Orientation = Orientation.Portrait,
            Margins = new MarginSettings { Top = 10 }
        },
                    Objects = {
            new ObjectSettings {
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8" }
            }
        }
                };

                var pdf = _converter.Convert(doc);
                return File(pdf, "application/pdf", "SmartBudgetSuggestions.pdf");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> BudgetAllocation()
        {
            try
            {
                var categories = await _budgetService.GetAllAsync(UserId);
                var monthlyIncome = await _budgetRepository.GetByUserAndMonthAsync(UserId, DateTime.Now.Year);

                if (monthlyIncome == null || monthlyIncome.Amount <= 0)
                {
                    TempData["ErrorMessage"] = "Please set your monthly Budget before viewing recommendations.";
                    return RedirectToAction("SetBudget", "Budget");
                }

                var recommendations = _budgetService.GetRecommendedBudget(Convert.ToDouble(monthlyIncome.Amount));

                // Update matching categories with recommended amounts
                foreach (var cat in categories)
                {
                    var rec = recommendations.FirstOrDefault(r => r.RecommendationId == cat.RecommendationId);
                    if (rec != null)
                    {
                        var dto = new BudgetCategoryDto
                        {
                            RecommendationId = rec.RecommendationId,
                            CategoryName = rec.CategoryName,
                            BudgetAmount = Convert.ToDecimal(rec.IdealAvgAmount),
                            UserId = cat.UserId
                        };
                        await _budgetService.UpdateAsync(dto);
                    }
                }

                // Send recommendations + info whether already added or not
                var model = recommendations.Select(r => new RecommendedBudgetDto
                {
                    RecommendationId = r.RecommendationId,
                    CategoryName = r.CategoryName,
                    IdealMinAmount = r.IdealMinAmount,
                    IdealAvgAmount = r.IdealAvgAmount,
                    IdealMaxAmount = r.IdealMaxAmount,
                    IsAdded = categories.Any(c => c.RecommendationId == r.RecommendationId)
                }).OrderBy(r => r.IsAdded).ToList();

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> ViewBudget()
        {
            try
            {
                var now = DateTime.Now;

                var budget = await _budgetRepository.GetByUserAndMonthAsync(UserId, now.Year);
                var expenses = await _expenseService.GetExpensesByMonthAsync(UserId, now.Year);

                if (budget == null || expenses.FirstOrDefault() == null)
                {
                    var model1 = new BudgetViewModel
                    {
                        Month = now.Month,
                        Year = now.Year,
                        BudgetAmount = budget?.Amount ?? 0,
                        TotalSpent = 0,
                        Remaining = 0
                    };
                    return View(model1);
                }
                var totalSpent = expenses.Sum(e => e.Amount);
                var remaining = budget != null ? budget.Amount - totalSpent : 0;

                var model = new BudgetViewModel
                {
                    Month = now.Month,
                    Year = now.Year,
                    BudgetAmount = budget?.Amount ?? 0,
                    TotalSpent = totalSpent,
                    Remaining = remaining
                };


                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> SetBudget()
        {
            try
            {
                var now = DateTime.Now;
                var existing = await _budgetRepository.GetByUserAndMonthAsync(UserId, now.Year);
                var model = new BudgetFormDto
                {
                    Month = now.Month,
                    Year = now.Year,
                    Amount = existing?.Amount ?? 0
                };
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetBudget(BudgetFormDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                var existing = await _budgetRepository.GetByUserAndMonthAsync(UserId, DateTime.Now.Year);
                if (existing != null)
                {
                    existing.Amount = model.Amount;
                    await _budgetRepository.UpdateAsync(existing);
                }
                else
                {
                    var budget = new MonthlyBudget
                    {
                        UserId = UserId,
                        Month = DateTime.Now.Month,
                        Year = DateTime.Now.Year,
                        Amount = model.Amount
                    };
                    await _budgetRepository.AddAsync(budget);
                }
                HttpContext.Session.Remove("UserBudget");
                HttpContext.Session.SetInt32("UserBudget", Convert.ToInt32(model.Amount));
                return RedirectToAction("BudgetAllocation");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
