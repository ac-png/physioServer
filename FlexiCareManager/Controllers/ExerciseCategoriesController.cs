using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Controllers
{
    [Authorize(Roles = "ADMINISTRATOR")]
    public class ExerciseCategoriesController : BaseController
    {
        private readonly FlexiCareManagerContext _context;

        public ExerciseCategoriesController(FlexiCareManagerContext context)
        {
            _context = context;
        }

        // GET: ExerciseCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExerciseCategory.ToListAsync());
        }

        // GET: ExerciseCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseCategory = await _context.ExerciseCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseCategory == null)
            {
                return NotFound();
            }

            return View(exerciseCategory);
        }

        // GET: ExerciseCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExerciseCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ExerciseCategory exerciseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseCategory);
        }

        // GET: ExerciseCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseCategory = await _context.ExerciseCategory.FindAsync(id);
            if (exerciseCategory == null)
            {
                return NotFound();
            }
            return View(exerciseCategory);
        }

        // POST: ExerciseCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ExerciseCategory exerciseCategory)
        {
            if (id != exerciseCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseCategoryExists(exerciseCategory.Id))
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
            return View(exerciseCategory);
        }

        // GET: ExerciseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseCategory = await _context.ExerciseCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseCategory == null)
            {
                return NotFound();
            }

            return View(exerciseCategory);
        }

        // POST: ExerciseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exerciseCategory = await _context.ExerciseCategory.FindAsync(id);
            if (exerciseCategory != null)
            {
                _context.ExerciseCategory.Remove(exerciseCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseCategoryExists(int id)
        {
            return _context.ExerciseCategory.Any(e => e.Id == id);
        }
    }
}
