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
    public class ProgrammeExercisesController : BaseController
    {
        private readonly FlexiCareManagerContext _context;

        public ProgrammeExercisesController(FlexiCareManagerContext context)
        {
            _context = context;
        }

        // GET: ProgrammeExercises
        // public async Task<IActionResult> Index()
        // {
        //     var FlexiCareManagerContext = _context.ProgrammeExercise.Include(p => p.Exercise).Include(p => p.Programme);
        //     return View(await FlexiCareManagerContext.ToListAsync());
        // }

        // GET: ProgrammeExercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmeExercise = await _context.ProgrammeExercise
                .Include(p => p.Exercise)
                .Include(p => p.Programme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programmeExercise == null)
            {
                return NotFound();
            }

            return View(programmeExercise);
        }

        // GET: ProgrammeExercises/Create
        public async Task<IActionResult> Create(int id)
        {
            var programme = await _context.Programme.FindAsync(id);
            if (programme == null)
            {
                return NotFound();
            }
            var programmeExercise = new ProgrammeExercise { Programme = programme, ProgrammeId = id};
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name");
            return View(programmeExercise);
        }

        // POST: ProgrammeExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExerciseId,ProgrammeId,Day,Notes")] ProgrammeExercise programmeExercise)
        {
            if (ModelState.IsValid)
            {
                var exercise = await _context.Exercise.FindAsync(programmeExercise.ExerciseId);
                if (exercise == null){
                    return BadRequest("");
                }
                var programme = await _context.Programme.FindAsync(programmeExercise.ProgrammeId);
                if (programme == null){
                    return BadRequest("");
                }
                programmeExercise.Programme = programme;
                programmeExercise.Exercise = exercise;
                _context.Add(programmeExercise);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Programmes", new {Id = programmeExercise.ProgrammeId});
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name", programmeExercise.ExerciseId);
            ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Name", programmeExercise.ProgrammeId);
            return View(programmeExercise);
        }

        // GET: ProgrammeExercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmeExercise = await _context.ProgrammeExercise.Include(pe => pe.Programme).FirstOrDefaultAsync(pe => pe.Id == id);
            if (programmeExercise == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name", programmeExercise.ExerciseId);
            return View(programmeExercise);
        }

        // POST: ProgrammeExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExerciseId,ProgrammeId,Day,Notes")] ProgrammeExercise programmeExercise)
        {
            if (id != programmeExercise.Id)
            {
                return NotFound();
            }
            programmeExercise.Exercise = await _context.Exercise.FindAsync(programmeExercise.ExerciseId) ?? new Exercise();
            programmeExercise.Programme = await _context.Programme.FindAsync(programmeExercise.ProgrammeId) ?? new Programme();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programmeExercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammeExerciseExists(programmeExercise.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Programmes", new {Id = programmeExercise!.ProgrammeId});
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name", programmeExercise.ExerciseId);
            return View(programmeExercise);
        }

        // GET: ProgrammeExercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmeExercise = await _context.ProgrammeExercise
                .Include(p => p.Exercise)
                .Include(p => p.Programme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programmeExercise == null)
            {
                return NotFound();
            }

            return View(programmeExercise);
        }

        // POST: ProgrammeExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programmeExercise = await _context.ProgrammeExercise.FindAsync(id);
            if (programmeExercise != null)
            {
                _context.ProgrammeExercise.Remove(programmeExercise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Programmes", new {Id = programmeExercise!.ProgrammeId});
        }

        private bool ProgrammeExerciseExists(int id)
        {
            return _context.ProgrammeExercise.Any(e => e.Id == id);
        }
    }
}
