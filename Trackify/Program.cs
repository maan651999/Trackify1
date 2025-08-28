using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using Trackify.Application.Interfaces;
using Trackify.Infrastructure;
using Trackify.Infrastructure.FitnessTracker.Services;
using Trackify.Infrastructure.Repositories;
using Trackify.Web.Filters;

var builder = WebApplication.CreateBuilder(args);

// 🔐 JWT Authentication init
JwtRefreshMiddleware.Initialize(builder.Configuration);

// ✅ DinkToPdf setup
var architectureFolder = "NativeBinaries";
var libPath = Path.Combine(Directory.GetCurrentDirectory(), architectureFolder, "libwkhtmltox.dll");
CustomAssemblyLoadContext.LoadUnmanagedLibrary(libPath);
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

// ✅ Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Application Services & Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();        // FIXED: expense repository
builder.Services.AddScoped<IMonthlyBudgetRepository, MonthlyBudgetRepository>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<INutritionRepository, NutritionService>();
builder.Services.AddScoped<IReport, ReportService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Optional direct service registrations (if you inject concrete class)
builder.Services.AddScoped<BudgetService>();
builder.Services.AddScoped<NutritionService>();
builder.Services.AddScoped<JwtAuthenticationAttribute>();

// ✅ HttpContext + View engine
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ICompositeViewEngine, CompositeViewEngine>();

// ✅ Refresh Token Storage (Global Dictionary)
builder.Services.AddSingleton<IDictionary<string, string>>(new Dictionary<string, string>());

// ✅ MVC + Session
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

// ❌ Pehle ye mat lagao
// app.UseMiddleware<JwtRefreshMiddleware>();

app.UseSession(); // ✅ pehle session enable karo
app.UseMiddleware<JwtRefreshMiddleware>();

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
