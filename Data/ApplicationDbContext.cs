﻿using FinFlow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryModel> Category { get; set; }

        public DbSet<ItemsModel> Items { get; set; }

        public DbSet<ExpenseModel> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Call the seed method
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel {Id = 1, Name = "Housing", /*Description = "Rent, mortgage payments, property taxes, home insurance"*/ },
                new CategoryModel { Id = 2, Name = "Utilities", /*Description = "Electricity, water, gas, internet, phone bills" */},
                new CategoryModel { Id = 3, Name = "Groceries", /*Description = "Food and household supplies" */},
                new CategoryModel { Id = 4, Name = "Transportation", /*Description = "Public transport, fuel, car maintenance"*/ },
                new CategoryModel { Id = 5, Name = "Healthcare", /*Description = "Health insurance, medical visits, medications"*/ },
                new CategoryModel { Id = 6, Name = "Debt and Savings", /*Description = "Loan repayments, savings contributions" */},
                new CategoryModel { Id = 7, Name = "Personal Care", /*Description = "Haircuts, skincare, gym memberships"*/ },
                new CategoryModel { Id = 8, Name = "Entertainment", /*Description = "Movies, dining out, hobbies"*/ },
                new CategoryModel { Id = 9, Name = "Education", /*Description = "Tuition, books, online courses"*/ },
                new CategoryModel { Id = 10, Name = "Miscellaneous", /*Description = "Travel, gifts, pet care"*/ }
            );
        }
    }
}
