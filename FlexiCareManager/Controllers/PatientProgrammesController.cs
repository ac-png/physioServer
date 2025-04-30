using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Controllers
{
    [Authorize(Roles = "ADMINISTRATOR, PHYSIO")]
    public class PatientProgrammesController : BaseController
    {
        private readonly FlexiCareManagerContext _context;

        public PatientProgrammesController(FlexiCareManagerContext context)
        {
            _context = context;
        }

        // // GET: PatientProgramme
        // public async Task<IActionResult> Index()
        // {
        //     var FlexiCareManagerContext = _context.PatientProgramme.Include(c => c.Patient).Include(c => c.Programme);
        //     return View(await FlexiCareManagerContext.ToListAsync());
        // }

        // GET: PatientProgramme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientProgramme = await _context.PatientProgramme
                .Include(pp => pp.Patient)
                .Include(pp => pp.Programme)
                .Include(pp => pp.Sessions)
                    .ThenInclude(s => s.Exercise)
                    .ThenInclude(s => s.ExerciseCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientProgramme == null)
            {
                return NotFound();
            }

            return View(patientProgramme);
        }

        // GET: PatientProgramme/Create
        public IActionResult Create(int id)
        {
            var patient = _context.Patient.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            var patientProgramme = new PatientProgramme { Patient = patient, PatientId = id};
            ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Name");
            return View(patientProgramme);
        }

        // POST: PatientProgramme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,ProgrammeId,StartDate,EndDate")] PatientProgramme patientProgramme)
        {
            if (ModelState.IsValid)
            {
                var programme = await _context.Programme.FindAsync(patientProgramme.ProgrammeId);
                if (programme == null){
                    return BadRequest("");
                }
                var patient = await _context.Patient.FindAsync(patientProgramme.PatientId);
                if (patient == null){
                    return BadRequest("");
                }
                patientProgramme.Programme = programme;
                patientProgramme.Patient = patient;
                var success = await patientProgramme.CreateProgramme(_context);
                if(success)
                {
                    return RedirectToAction("Details", "Patients", new {Id = patientProgramme.PatientId});
                }
            }
            ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Name", patientProgramme.ProgrammeId);
            return View(patientProgramme);
        }

        // GET: PatientProgramme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientProgramme = await _context.PatientProgramme.FindAsync(id);
            if (patientProgramme == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", patientProgramme.PatientId);
            ViewData["ProgrammeId"] = new SelectList(_context.Set<Programme>(), "Id", "Id", patientProgramme.ProgrammeId);
            return View(patientProgramme);
        }

        // POST: PatientProgramme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,ProgrammeId,StartDate,EndDate")] PatientProgramme patientProgramme)
        {
            if (id != patientProgramme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientProgramme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientProgrammeExists(patientProgramme.Id))
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
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", patientProgramme.PatientId);
            ViewData["ProgrammeId"] = new SelectList(_context.Set<Programme>(), "Id", "Id", patientProgramme.ProgrammeId);
            return View(patientProgramme);
        }

        // GET: PatientProgramme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientProgramme = await _context.PatientProgramme
                .Include(c => c.Patient)
                .Include(c => c.Programme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientProgramme == null)
            {
                return NotFound();
            }

            return View(patientProgramme);
        }

        // POST: PatientProgramme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientProgramme = await _context.PatientProgramme.FindAsync(id);
            if (patientProgramme == null)
            {
                return BadRequest("");
            }

            var patientId = patientProgramme.PatientId;
            
            foreach(var session in _context.Session.Where(s => s.PatientProgrammeId == id))
            {
                _context.Session.Remove(session);
            }
            _context.PatientProgramme.Remove(patientProgramme);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Patients", new {Id = patientId} );
        }

        private bool PatientProgrammeExists(int id)
        {
            return _context.PatientProgramme.Any(e => e.Id == id);
        }
    }
}
