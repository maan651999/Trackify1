using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackify.Domain.Entities;
using Trackify.Domain.FitnessEntity;

namespace Trackify.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<MonthlyBudget> MonthlyBudgets { get; set; }
        public DbSet<BudgetCategory> BudgetCategories { get; set; }
        public DbSet<BudgetRecommendation> BudgetRecommendations { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            WorkoutSeed.Seed(modelBuilder);

            // Diffrent-reference (User → HelpRequest)
            modelBuilder.Entity<MonthlyBudget>()
               .HasOne(al => al.User)
               .WithMany(a => a.MonthlyBudgets)
               .HasForeignKey(al => al.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Expense>()
             .HasOne(al => al.User)
             .WithMany(a => a.Expenses)
             .HasForeignKey(al => al.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BudgetCategory>()
           .HasOne(al => al.User)
           .WithMany(a => a.BudgetCategories)
           .HasForeignKey(al => al.UserId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Expense>()
           .HasOne(al => al.BudgetCategory)
           .WithMany(a => a.Expenses)
           .HasForeignKey(al => al.CategoryId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BudgetCategory>()
          .HasOne(al => al.BudgetRecommendation)
          .WithMany(a => a.BudgetCategories)
          .HasForeignKey(al => al.RecommendationId)
          .OnDelete(DeleteBehavior.Cascade);

            //Default Date
            modelBuilder.Entity<User>()
            .Property(u => u.CreatedDate)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

            // Self-reference (AdminLog → AdminLog)
            //modelBuilder.Entity<Admin>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.HasOne(e => e.ParentLog)
            //          .WithMany(e => e.ChildLogs)
            //          .HasForeignKey(e => e.AdminId)
            //          .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            // Disable any accidental cascade delete globally
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
    }
}
