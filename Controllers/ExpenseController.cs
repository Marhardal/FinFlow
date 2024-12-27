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

namespace FinFlow.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expense
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Expenses.Include(e => e.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Expense/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseModel = await _context.Expenses
                .Include(e => e.Item)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseModel == null)
            {
                return NotFound();
            }

            return View(expenseModel);
        }

        // GET: Expense/Create
        public IActionResult Create(int BudgetID)
        {
            //ViewData["SelectedItemId"] = new SelectList(_context.Items, "Id", "Id");
            var expenses = new ExpenseModel
            {
                items = _context.Items.ToList()
            };
            ViewBag.BudgetID = BudgetID;

            // Load other necessary data for the view
            ViewData["SelectedItemId"] = new SelectList(_context.Items, "Id", "Name");
            return View(expenses);
        }

        // POST: Expense/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemId,Amount,Quantity,Notes,Date")] ExpenseModel expenseModel, int BudgetID)
        {
            if (ModelState.IsValid)
            {
                expenseModel.BudgetID = BudgetID;
                _context.Add(expenseModel);
                await _context.SaveChangesAsync(); 
                return RedirectToAction("Details", "Budget", new { id = BudgetID });
            }
            ViewData["SelectedItemId"] = new SelectList(_context.Items, "Id", "Id", expenseModel.ItemId);
            return View(expenseModel);
        }

        // GET: Expense/Edit/5
        public async Task<IActionResult> Edit(int? ExpenseID, int? BudgetID)
        {
            if (ExpenseID == null)
            {
                return NotFound();
            }

            var expenseModel = await _context.Expenses.FindAsync(ExpenseID);
            if (expenseModel == null)
            {
                return NotFound();
            }
            ViewData["SelectedItemId"] = new SelectList(_context.Items, "Id", "Id", expenseModel.ItemId);
            ViewData["Items"] = _context.Items.ToList();
            ViewBag.BudgetID = BudgetID;
            return View(expenseModel);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,ItemId,Amount,Quantity,Notes,Date")] ExpenseModel expenseModel, int? BudgetID)
        {
            if (Id != expenseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    expenseModel.BudgetID = BudgetID;
                    _context.Update(expenseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseModelExists(expenseModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Budget", new { id = BudgetID });
            }
            ViewData["SelectedItemId"] = new SelectList(_context.Items, "Id", "Id", expenseModel.ItemId);
            return View(expenseModel);
        }

        // GET: Expense/Delete/5
        public async Task<IActionResult> Delete(int? ExpenseID)
        {
            if (ExpenseID == null)
            {
                return NotFound();
            }

            var expenseModel = await _context.Expenses
                .Include(e => e.Item)
                .FirstOrDefaultAsync(m => m.Id == ExpenseID);
            if (expenseModel == null)
            {
                return NotFound();
            }

            return View(expenseModel);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenseModel = await _context.Expenses.FindAsync(id);
            if (expenseModel != null)
            {
                _context.Expenses.Remove(expenseModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseModelExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
