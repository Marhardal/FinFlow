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
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var items = _context.Items.Include(i => i.Category).ToList();
            return View(items);
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsModel = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemsModel == null)
            {
                return NotFound();
            }

            return View(itemsModel);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            var model = new ItemsModel
            {
                Categories = _context.Category.ToList() // Fetch categories from the database
            };

            return View(model);
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SelectedCategoryId,Measurement")] ItemsModel itemsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Reload categories to repopulate the dropdown
            itemsModel.Categories = _context.Category.ToList();
            return View(itemsModel);
        }


        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsModel = await _context.Items.FindAsync(id);
            if (itemsModel == null)
            {
                return NotFound();
            }
            return View(itemsModel);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Measurement")] ItemsModel itemsModel)
        {
            if (id != itemsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsModelExists(itemsModel.Id))
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
            return View(itemsModel);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsModel = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemsModel == null)
            {
                return NotFound();
            }

            return View(itemsModel);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemsModel = await _context.Items.FindAsync(id);
            if (itemsModel != null)
            {
                _context.Items.Remove(itemsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsModelExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
