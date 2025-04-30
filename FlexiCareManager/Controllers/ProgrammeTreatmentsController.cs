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
    public class ProgrammeTreatmentsController : BaseController
    {
        private readonly FlexiCareManagerContext _context;

        public ProgrammeTreatmentsController(FlexiCareManagerContext context)
        {
            _context = context;
        }

        // // GET: ProgrammeTreatments
        // public async Task<IActionResult> Index()
        // {
        //     var FlexiCareManagerContext = _context.ProgrammeTreatment.Include(p => p.Programme).Include(p => p.Treatment);
        //     return View(await FlexiCareManagerContext.ToListAsync());
        // }

        // // GET: ProgrammeTreatments/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var programmeTreatment = await _context.ProgrammeTreatment
        //         .Include(p => p.Programme)
        //         .Include(p => p.Treatment)
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (programmeTreatment == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(programmeTreatment);
        // }

        // GET: ProgrammeTreatments/Create
        public IActionResult Create(int Id)
        {
            var programme = _context.Programme.FirstOrDefault(p => p.Id == Id);
            if (programme == null){
                return NotFound();
            }
            var programmeTreatment = new ProgrammeTreatment {Programme = programme, ProgrammeId = programme.Id};
            ViewData["TreatmentId"] = new SelectList(_context.Set<Treatment>(), "Id", "Name");
            return View(programmeTreatment);
        }

        // POST: ProgrammeTreatments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TreatmentId,ProgrammeId")] ProgrammeTreatment programmeTreatment)
        {
            programmeTreatment.Id = 0;
            if (ModelState.IsValid)
            {
                var programme = _context.Programme.FirstOrDefault(p => p.Id == programmeTreatment.ProgrammeId);
                if (programme == null){ return BadRequest(""); }
                var treatment = _context.Treatment.FirstOrDefault(t => t.Id == programmeTreatment.TreatmentId);
                if (treatment == null){ return BadRequest(""); }
                programmeTreatment.Programme = programme;
                programmeTreatment.Treatment = treatment;
                _context.Add(programmeTreatment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Programmes", new {Id = programmeTreatment.ProgrammeId});
            }
            ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Id", programmeTreatment.ProgrammeId);
            ViewData["TreatmentId"] = new SelectList(_context.Set<Treatment>(), "Id", "Id", programmeTreatment.TreatmentId);
            return View(programmeTreatment);
        }

        // // GET: ProgrammeTreatments/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var programmeTreatment = await _context.ProgrammeTreatment.FindAsync(id);
        //     if (programmeTreatment == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Id", programmeTreatment.ProgrammeId);
        //     ViewData["TreatmentId"] = new SelectList(_context.Set<Treatment>(), "Id", "Id", programmeTreatment.TreatmentId);
        //     return View(programmeTreatment);
        // }

        // // POST: ProgrammeTreatments/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,TreatmentId,ProgrammeId")] ProgrammeTreatment programmeTreatment)
        // {
        //     if (id != programmeTreatment.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(programmeTreatment);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!ProgrammeTreatmentExists(programmeTreatment.Id))
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
        //     ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Id", programmeTreatment.ProgrammeId);
        //     ViewData["TreatmentId"] = new SelectList(_context.Set<Treatment>(), "Id", "Id", programmeTreatment.TreatmentId);
        //     return View(programmeTreatment);
        // }

        // GET: ProgrammeTreatments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmeTreatment = await _context.ProgrammeTreatment
                .Include(p => p.Programme)
                .Include(p => p.Treatment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programmeTreatment == null)
            {
                return NotFound();
            }

            return View(programmeTreatment);
        }

        // POST: ProgrammeTreatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programmeTreatment = await _context.ProgrammeTreatment.FindAsync(id);
            if (programmeTreatment == null)
            {
                return BadRequest("");
            }

            _context.ProgrammeTreatment.Remove(programmeTreatment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Programmes", new {Id = programmeTreatment.ProgrammeId});
        }

        private bool ProgrammeTreatmentExists(int id)
        {
            return _context.ProgrammeTreatment.Any(e => e.Id == id);
        }
    }
}
