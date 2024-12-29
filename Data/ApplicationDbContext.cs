using FinFlow.Models;
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

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<IncomeCategoryModel> IncomeCategories { get; set; }

        public DbSet<TransTypeModel> TransactionType { get; set; }

        public DbSet<PaymentTypeModel> PaymentTypes { get; set; }

        public DbSet<IncomeModel> Incomes { get; set; }

        public DbSet<ItemsModel> Items { get; set; }

        public DbSet<ExpenseModel> Expenses { get; set; }

        public DbSet<BudgetModel> Budgets { get; set; }

        public DbSet<TransactionModel> Transactions { get; set; }

        public DbSet<AttachmentModel> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExpenseModel>()
              .HasOne(e => e.Budget) // Each Expense has one Budget
              .WithMany(b => b.expenses) // Each Budget can have many Expenses
              .HasForeignKey(e => e.BudgetID) // Foreign key in ExpenseModel
              .OnDelete(DeleteBehavior.Cascade); // Optional: Define delete behavior

            modelBuilder.Entity<ItemsModel>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId);

            modelBuilder.Entity<IncomeModel>()
                .HasOne(a => a.incomeCategory)
                .WithMany(d => d.incomes)
                .HasForeignKey(a => a.incCategoryID);


            modelBuilder.Entity<AttachmentModel>()
                .HasOne(a => a.Transaction)
                .WithMany(t => t.Attachments)
                .HasForeignKey(a => a.TransactionID);

            modelBuilder.Entity<TransactionModel>()
                .HasOne(p => p.PaymentType)
                .WithOne(t => t.Transaction)
                .HasForeignKey<TransactionModel>(t => t.PaymentTypeID);

            modelBuilder.Entity<TransactionModel>()
                .HasOne(tr => tr.TransType)
                .WithOne(t => t.Transaction)
                .HasForeignKey<TransactionModel>(t => t.TypeID);

            modelBuilder.Entity<IncomeCategoryModel>().HasData(
                new IncomeCategoryModel { Id = 1, Name = "Salary"/*, Description = "Monthly salary from employment" */},
                new IncomeCategoryModel { Id = 2, Name = "Freelance"/*, Description = "Income from freelance work"*/ },
                new IncomeCategoryModel { Id = 3, Name = "Investments"/*, Description = "Returns from investments"*/ },
                new IncomeCategoryModel { Id = 4, Name = "Bonus" },
                new IncomeCategoryModel { Id = 5, Name = "Commissions" },
                new IncomeCategoryModel { Id = 6, Name = "Gifts" }
            );

            // Call the seed method
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Name = "Housing", /*Description = "Rent, mortgage payments, property taxes, home insurance"*/ },
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

            // Call the seed method
            modelBuilder.Entity<PaymentTypeModel>().HasData(
                new PaymentTypeModel { ID = 1, Name = "Cash", },
                new PaymentTypeModel { ID = 2, Name = "Credit Card",},
                new PaymentTypeModel { ID = 3, Name = "Debit Card", },
                new PaymentTypeModel { ID = 4, Name = "Bank Transfer", },
                new PaymentTypeModel { ID = 5, Name = "Mobile Money",},
                new PaymentTypeModel { ID = 6, Name = "Cheque",},
                new PaymentTypeModel { ID = 7, Name = "Cryptocurrency",},
                new PaymentTypeModel { ID = 8, Name = "Digital Wallets",},
                new PaymentTypeModel { ID = 9, Name = "Prepaid Card",},
                new PaymentTypeModel { ID = 10, Name = "Online Payment Gateways", }
            );

            modelBuilder.Entity<TransTypeModel>().HasData(
                new TransTypeModel { Id = 1, Name = "Income"},
                new TransTypeModel { Id = 2, Name = "Expense" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
