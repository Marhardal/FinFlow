using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinFlow.Data;
using FinFlow.Models;
using FinFlow.Data.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace FinFlow.Controllers
{
    public class BudgetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BudgetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Budget
        public async Task<IActionResult> Index()
        {
            return View(await _context.Budgets.ToListAsync());
        }

        // GET: Budget/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetModel = await _context.Budgets
    .Include(b => b.expenses)
    .ThenInclude(e => e.Item) // Include related Item if it's a navigation property
    .FirstOrDefaultAsync(b => b.Id == id);
            if (budgetModel == null)
            {
                return NotFound();
            }

            return View(budgetModel);
        }

        // GET: Budget/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Budget/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Status,Amount,remindon,CreatedDate")] BudgetModel budgetModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budgetModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(budgetModel);
        }

        // GET: Budget/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetModel = await _context.Budgets.FindAsync(id);
            if (budgetModel == null)
            {
                return NotFound();
            }
            return View(budgetModel);
        }

        // POST: Budget/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Status,Amount,remindon,CreatedDate")] BudgetModel budgetModel)
        {
            if (id != budgetModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budgetModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetModelExists(budgetModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(budgetModel);
        }

        // GET: Budget/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetModel = await _context.Budgets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budgetModel == null)
            {
                return NotFound();
            }

            return View(budgetModel);
        }

        // POST: Budget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budgetModel = await _context.Budgets.FindAsync(id);
            if (budgetModel != null)
            {
                _context.Budgets.Remove(budgetModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetModelExists(int id)
        {
            return _context.Budgets.Any(e => e.Id == id);
        }

        private async Task<BudgetModel> GetBudgetDetailsForPdfAsync(int id)
        {
            var budgetModel = await _context.Budgets
                .Include(b => b.expenses)
                .ThenInclude(e => e.Item) // Include related Item if it's a navigation property
                .FirstOrDefaultAsync(b => b.Id == id);

            return budgetModel;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateBudgetPdf(int id)
        {
            var budgetModel = await GetBudgetDetailsForPdfAsync(id);
            if (budgetModel == null)
            {
                return NotFound("Budget not found.");
            }

            using (var stream = new MemoryStream())
            {
                // Create a PDF document
                var document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, stream);

                document.Open();

                // Add a title
                document.Add(new iTextSharp.text.Paragraph($"Budget Details: {budgetModel.Name}"));

                // Create a table for budget expenses
                var table = new PdfPTable(3); // 4 columns: Item, Amount, Quantity, Date
                table.AddCell("Item");
                table.AddCell("Amount");
                table.AddCell("Quantity");
                //table.AddCell("Date");

                // Loop through the expenses
                foreach (var expense in budgetModel.expenses)
                {
                    table.AddCell(expense.Item?.Name ?? "N/A");
                    table.AddCell(expense.Amount.ToString("C", new CultureInfo("en-MW")));
                    table.AddCell(expense.Quantity.ToString());
                    //table.AddCell(expense.Date.ToString());
                }

                // Add table to the document
                document.Add(table);
                document.Close();

                // Return the PDF file
                return File(stream.ToArray(), "application/pdf", budgetModel.Name + " Expenses.pdf");
            }
        }

    }
}