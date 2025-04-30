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
    [Authorize(Roles = "ADMINISTRATOR, PHYSIO")]
    public class SessionsController : BaseController
    {
        private readonly FlexiCareManagerContext _context;

        public SessionsController(FlexiCareManagerContext context)
        {
            _context = context;
        }

        // // GET: Sessions
        // public async Task<IActionResult> Index(int id)
        // {
        //     var sessions = _context.Session
        //         .Include(s => s.Exercise)
        //         .Include(s => s.ExerciseCategory)
        //         .Where(s => s.PatientProgrammeId == id);
        //     return View(await sessions.ToListAsync());
        // }

        // // GET: Sessions/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var session = await _context.Session
        //         .Include(s => s.Patient)
        //         .Include(s => s.Exercise)
        //         .Include(s => s.ExerciseCategory)
        //         .Include(s => s.Programme)
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (session == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(session);
        // }

        // // GET: Sessions/Create
        // public IActionResult Create()
        // {
        //     ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id");
        //     ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id");
        //     ViewData["ExerciseCategoryId"] = new SelectList(_context.ExerciseCategory, "Id", "Id");
        //     ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Id");
        //     return View();
        // }

        // // POST: Sessions/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,PatientId,ProgrammeId,ExerciseId,ExerciseCategoryId,ExerciseDate,Notes,Done")] Session session)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(session);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", session.PatientId);
        //     ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id", session.ExerciseId);
        //     ViewData["ExerciseCategoryId"] = new SelectList(_context.ExerciseCategory, "Id", "Id", session.ExerciseCategoryId);
        //     ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Id", session.ProgrammeId);
        //     return View(session);
        // }

        // // GET: Sessions/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var session = await _context.Session.FindAsync(id);
        //     if (session == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", session.PatientId);
        //     ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id", session.ExerciseId);
        //     ViewData["ExerciseCategoryId"] = new SelectList(_context.ExerciseCategory, "Id", "Id", session.ExerciseCategoryId);
        //     ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Id", session.ProgrammeId);
        //     return View(session);
        // }

        // // POST: Sessions/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,ProgrammeId,ExerciseId,ExerciseCategoryId,ExerciseDate,Notes,Done")] Session session)
        // {
        //     if (id != session.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(session);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!SessionExists(session.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", session.PatientId);
        //     ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id", session.ExerciseId);
        //     ViewData["ExerciseCategoryId"] = new SelectList(_context.ExerciseCategory, "Id", "Id", session.ExerciseCategoryId);
        //     ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Id", session.ProgrammeId);
        //     return View(session);
        // }

        // // GET: Sessions/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var session = await _context.Session
        //         .Include(s => s.Patient)
        //         .Include(s => s.Exercise)
        //         .Include(s => s.ExerciseCategory)
        //         .Include(s => s.Programme)
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (session == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(session);
        // }

        // // POST: Sessions/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var session = await _context.Session.FindAsync(id);
        //     if (session != null)
        //     {
        //         _context.Session.Remove(session);
        //     }

        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        private bool SessionExists(int id)
        {
            return _context.Session.Any(e => e.Id == id);
        }
    }
}
