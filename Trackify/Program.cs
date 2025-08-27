using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Loader;
using Trackify.Application.Interfaces;
using Trackify.Infrastructure;
using Trackify.Infrastructure.FitnessTracker.Services;
using Trackify.Infrastructure.Repositories;
using Trackify.Web.Filters;

var builder = WebApplication.CreateBuilder(args);
Authentication.Initialize(builder.Configuration);

var architectureFolder = "NativeBinaries";
var libPath = Path.Combine(Directory.GetCurrentDirectory(), architectureFolder, "libwkhtmltox.dll");

// Load the native DLL manually
CustomAssemblyLoadContext.LoadUnmanagedLibrary(libPath);

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IExpenseService, ExpenseRepository>();
builder.Services.AddScoped<IMonthlyBudgetRepository, MonthlyBudgetRepository>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<BudgetService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ICompositeViewEngine, CompositeViewEngine>();
builder.Services.AddScoped<INutritionRepository,NutritionService>();
builder.Services.AddScoped<IReport,ReportService>();
builder.Services.AddScoped<NutritionService>();
builder.Services.AddScoped<JwtAuthenticationAttribute>();




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();


var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
