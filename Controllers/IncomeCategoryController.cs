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
    public class IncomeCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncomeCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IncomeCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncomeCategories.ToListAsync());
        }

        // GET: IncomeCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeCategoryModel = await _context.IncomeCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeCategoryModel == null)
            {
                return NotFound();
            }

            return View(incomeCategoryModel);
        }

        // GET: IncomeCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncomeCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] IncomeCategoryModel incomeCategoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incomeCategoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incomeCategoryModel);
        }

        // GET: IncomeCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeCategoryModel = await _context.IncomeCategories.FindAsync(id);
            if (incomeCategoryModel == null)
            {
                return NotFound();
            }
            return View(incomeCategoryModel);
        }

        // POST: IncomeCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] IncomeCategoryModel incomeCategoryModel)
        {
            if (id != incomeCategoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeCategoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeCategoryModelExists(incomeCategoryModel.Id))
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
            return View(incomeCategoryModel);
        }

        // GET: IncomeCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeCategoryModel = await _context.IncomeCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeCategoryModel == null)
            {
                return NotFound();
            }

            return View(incomeCategoryModel);
        }

        // POST: IncomeCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incomeCategoryModel = await _context.IncomeCategories.FindAsync(id);
            if (incomeCategoryModel != null)
            {
                _context.IncomeCategories.Remove(incomeCategoryModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeCategoryModelExists(int id)
        {
            return _context.IncomeCategories.Any(e => e.Id == id);
        }
    }
}
