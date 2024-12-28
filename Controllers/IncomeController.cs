using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinFlow.Data;
using FinFlow.Models;

namespace FinFlow.Controllers
{
    public class IncomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Income
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Incomes.Include(i => i.incomeCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Income/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeModel = await _context.Incomes
                .Include(i => i.incomeCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeModel == null)
            {
                return NotFound();
            }

            return View(incomeModel);
        }

        // GET: Income/Create
        public IActionResult Create()
        {
            var income = new IncomeModel
            {
                IncomeCategories = _context.IncomeCategories.ToList(),
            };
            ViewData["CategoryID"] = new SelectList(_context.IncomeCategories, "Id", "Id");
            return View(income);
        }

        // POST: Income/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,incCategoryID,Name,Description,Amount,Date,CreatedAt")] IncomeModel incomeModel)
        {
            if (ModelState.IsValid)
            {
                //incomeModel.incCategoryID = ;
                _context.Add(incomeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.IncomeCategories, "Id", "Id", incomeModel.incCategoryID);
            return View(incomeModel);
        }

        // GET: Income/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeModel = await _context.Incomes.FindAsync(id);
            if (incomeModel == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.IncomeCategories, "Id", "Id", incomeModel.incCategoryID);
            ViewData["Categories"] = _context.IncomeCategories.ToList();
            return View(incomeModel);
        }

        // POST: Income/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,incCategoryID,Name,Description,Amount,Date,CreatedAt")] IncomeModel incomeModel)
        {
            if (id != incomeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeModelExists(incomeModel.Id))
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
            ViewData["CategoryID"] = new SelectList(_context.IncomeCategories, "Id", "Id", incomeModel.incCategoryID);
            return View(incomeModel);
        }

        // GET: Income/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeModel = await _context.Incomes
                .Include(i => i.incomeCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeModel == null)
            {
                return NotFound();
            }

            return View(incomeModel);
        }

        // POST: Income/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incomeModel = await _context.Incomes.FindAsync(id);
            if (incomeModel != null)
            {
                _context.Incomes.Remove(incomeModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeModelExists(int id)
        {
            return _context.Incomes.Any(e => e.Id == id);
        }
    }
}
